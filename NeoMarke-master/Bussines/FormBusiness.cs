using Data;
using Entity.DTOs;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Microsoft.SqlServer.Server;
using Utilities.Exceptions;

namespace Business;

/// <summary>
/// Clase de negocio encargada de la lógica relacionada con los formularios del sistema.
/// </summary>
public class FormBusiness
{
    private readonly FormData _formData;
    private readonly ILogger _logger;

    public FormBusiness(FormData formData, ILogger logger)
    {
        _formData = formData;
        _logger = logger;
    }

    // Método para obtener todos los formularios como DTOs
    public async Task<IEnumerable<FormDto>> GetAllFormsAsync()
    {
        try
        {
            var forms = await _formData.GetAllAsync();
            var formsDTO = new List<FormDto>();

            foreach (var form in forms)
            {
                formsDTO.Add(new FormDto
                {
                    Id = form.Id,
                    Description = form.Description,
                    Status = form.Status,
                    Title = form.Title
                });
            }

            return formsDTO;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todos los formularios");
            throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de formularios", ex);
        }
    }

    // Método para obtener un formulario por ID como DTO
    public async Task<FormDto> GetFormByIdAsync(int id)
    {
        if (id <= 0)
        {
            _logger.LogWarning("Se intentó obtener un formulario con ID inválido: {FormId}", id);
            throw new Utilities.Exceptions.ValidationException("id", "El ID del formulario debe ser mayor que cero");
        }

        try
        {
            var form = await _formData.GetByIdAsync(id);
            if (form == null)
            {
                _logger.LogInformation("No se encontró ningún formulario con ID: {FormId}", id);
                throw new EntityNotFoundException("Form", id);
            }

            return new FormDto
            {
                Id = form.Id,
                Description = form.Description,
                Status = form.Status,
                Title = form.Title
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener el formulario con ID: {FormId}", id);
            throw new ExternalServiceException("Base de datos", $"Error al recuperar el formulario con ID {id}", ex);
        }
    }

    // Método para crear un formulario desde un DTO
    public async Task<FormDto> CreateFormAsync(FormDto formDto)
    {
        try
        {
            ValidateForm(formDto);

            var form = new Form
            {
                Title = formDto.Title,
                Description = formDto.Description
            };

            var createdForm = await _formData.CreateAsync(form);

            return new FormDto
            {
                Id = createdForm.Id,
                Title = createdForm.Title,
                Description = createdForm.Description,
                Status = createdForm.Status
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear nuevo formulario: {FormTitle}", formDto?.Title ?? "null");
            throw new ExternalServiceException("Base de datos", "Error al crear el formulario", ex);
        }
    }

    // Método para validar el DTO
    private void ValidateForm(FormDto formDto)
    {
        if (formDto == null)
        {
            throw new Utilities.Exceptions.ValidationException("El objeto formulario no puede ser nulo");
        }

        if (string.IsNullOrWhiteSpace((string?)formDto.Title))
        {
            _logger.LogWarning("Se intentó crear/actualizar un formulario con Title vacío");
            throw new Utilities.Exceptions.ValidationException("Title", "El título del formulario es obligatorio");
        }
    }
}