using Data;
using Entity.DTO;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business;

/// <summary>
/// Clase de negocio encargada de la lógica relacionada con el inventario del sistema.
/// </summary>
public class InventoryBusiness
{
    private readonly InventoryData _inventoryData;
    private readonly ILogger _logger;

    public InventoryBusiness(InventoryData inventoryData, ILogger logger)
    {
        _inventoryData = inventoryData;
        _logger = logger;
    }

    // Método para obtener todos los inventarios como DTOs
    public async Task<IEnumerable<InventoryDto>> GetAllInventoriesAsync()
    {
        try
        {
            var inventories = await _inventoryData.GetAllAsync();
            var inventoriesDTO = new List<InventoryDto>();

            foreach (var inventory in inventories)
            {
                inventoriesDTO.Add(new InventoryDto
                {
                    Id = inventory.Id,
                    ProductName = inventory.ProductName,
                    StatusPrevious = inventory.StatusPrevious,
                    StatusNew = inventory.StatusNew,
                    Observations = inventory.Observations,
                    ZoneItem = inventory.ZoneItem
                });
            }

            return inventoriesDTO;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todos los inventarios");
            throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de inventarios", ex);
        }
    }

    // Método para obtener un inventario por ID como DTO
    public async Task<InventoryDto> GetInventoryByIdAsync(int id)
    {
        if (id <= 0)
        {
            _logger.LogWarning("Se intentó obtener un inventario con ID inválido: {InventoryId}", id);
            throw new Utilities.Exceptions.ValidationException("id", "El ID del inventario debe ser mayor que cero");
        }

        try
        {
            var inventory = await _inventoryData.GetByIdAsync(id);
            if (inventory == null)
            {
                _logger.LogInformation("No se encontró ningún inventario con ID: {InventoryId}", id);
                throw new EntityNotFoundException("Inventory", id);
            }

            return new InventoryDto
            {
                Id = inventory.Id,
                StatusPrevious = inventory.StatusPrevious,
                StatusNew = inventory.StatusNew,
                ZoneItem = inventory.ZoneItem
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener el inventario con ID: {InventoryId}", id);
            throw new ExternalServiceException("Base de datos", $"Error al recuperar el inventario con ID {id}", ex);
        }
    }

    // Método para crear un inventario desde un DTO
    public async Task<InventoryDto> CreateInventoryAsync(InventoryDto inventoryDto)
    {
        try
        {
            ValidateInventory(inventoryDto);

            var inventory = new Inventory
            {
                Id = inventoryDto.Id,
                StatusPrevious = inventoryDto.StatusPrevious,
                StatusNew = inventoryDto.StatusNew,
                ZoneItem = inventoryDto.ZoneItem

            };

            var createdInventory = await _inventoryData.CreateAsync(inventory);

            return new InventoryDto
            {
                Id = inventory.Id,
                StatusPrevious = inventory.StatusPrevious,
                StatusNew = inventory.StatusNew,
                ZoneItem = inventory.ZoneItem
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear nuevo inventario: {ProductName}", inventoryDto?.ProductName ?? "null");
            throw new ExternalServiceException("Base de datos", "Error al crear el inventario", ex);
        }
    }

    // Método para validar el DTO
    private void ValidateInventory(InventoryDto inventoryDto)
    {
        if (inventoryDto == null)
        {
            throw new Utilities.Exceptions.ValidationException("El objeto inventario no puede ser nulo");
        }

        if (string.IsNullOrWhiteSpace(inventoryDto.ProductName))
        {
            _logger.LogWarning("Se intentó crear/actualizar un inventario con ProductName vacío");
            throw new Utilities.Exceptions.ValidationException("ProductName", "El nombre del producto es obligatorio");
        }
    }
}
