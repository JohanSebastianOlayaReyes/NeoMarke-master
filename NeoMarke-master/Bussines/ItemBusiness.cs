using Data;
using Entity.DTO;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business;

/// <summary>
/// Clase de negocio encargada de la lógica relacionada con los ítems del sistema.
/// </summary>
public class ItemBusiness
{
    private readonly ItemData _itemData;
    private readonly ILogger _logger;

    public ItemBusiness(ItemData itemData, ILogger logger)
    {
        _itemData = itemData;
        _logger = logger;
    }

    // Método para obtener todos los ítems como DTOs
    public async Task<IEnumerable<ItemDto>> GetAllItemsAsync()
    {
        try
        {
            var items = await _itemData.GetAllAsync();
            var itemsDTO = new List<ItemDto>();

            foreach (var item in items)
            {
                itemsDTO.Add(new ItemDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description
                });
            }

            return itemsDTO;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todos los ítems");
            throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de ítems", ex);
        }
    }

    // Método para obtener un ítem por ID como DTO
    public async Task<ItemDto> GetItemByIdAsync(int id)
    {
        if (id <= 0)
        {
            _logger.LogWarning("Se intentó obtener un ítem con ID inválido: {ItemId}", id);
            throw new ValidationException("id", "El ID del ítem debe ser mayor que cero");
        }

        try
        {
            var item = await _itemData.GetByIdAsync(id);
            if (item == null)
            {
                _logger.LogInformation("No se encontró ningún ítem con ID: {ItemId}", id);
                throw new EntityNotFoundException("Item", id);
            }

            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener el ítem con ID: {ItemId}", id);
            throw new ExternalServiceException("Base de datos", $"Error al recuperar el ítem con ID {id}", ex);
        }
    }

    // Método para crear un ítem desde un DTO
    public async Task<ItemDto> CreateItemAsync(ItemDto itemDto)
    {
        try
        {
            ValidateItem(itemDto);

            var item = new Item
            {
                Name = itemDto.Name,
                Description = itemDto.Description
            };

            var itemCreado = await _itemData.CreateAsync(item);

            return new ItemDto
            {
                Id = itemCreado.Id,
                Name = itemCreado.Name,
                Description = itemCreado.Description
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear nuevo ítem: {ItemNombre}", itemDto?.Name ?? "null");
            throw new ExternalServiceException("Base de datos", "Error al crear el ítem", ex);
        }
    }

    // Método para validar el DTO
    private void ValidateItem(ItemDto itemDto)
    {
        if (itemDto == null)
        {
            throw new ValidationException("El objeto ítem no puede ser nulo");
        }

        if (string.IsNullOrWhiteSpace(itemDto.Name))
        {
            _logger.LogWarning("Se intentó crear/actualizar un ítem con Name vacío");
            throw new ValidationException("Name", "El Name del ítem es obligatorio");
        }
    }
}
