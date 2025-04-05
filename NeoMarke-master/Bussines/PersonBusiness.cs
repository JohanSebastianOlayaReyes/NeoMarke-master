using Data;
using Entity.DTO;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business;

/// <summary>
/// Clase de negocio encargada de la lógica relacionada con las personas del sistema.
/// </summary>
public class PersonBusiness
{
    private readonly PersonData _personData;
    private readonly ILogger _logger;

    public PersonBusiness(PersonData personData, ILogger logger)
    {
        _personData = personData;
        _logger = logger;
    }

    // Método para obtener todas las personas como DTOs
    public async Task<IEnumerable<PersonDto>> GetAllPersonsAsync()
    {
        try
        {
            var persons = await _personData.GetAllAsync();
            var personsDTO = new List<PersonDto>();

            foreach (var person in persons)
            {
                personsDTO.Add(new PersonDto
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    PhoneNumber = person.PhoneNumber,
                    Email = person.Email,
                    TypeIndification = person.TypeIndification,
                    NumberIndification = person.NumberIndification
                });
            }

            return personsDTO;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todas las personas");
            throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de personas", ex);
        }
    }

    // Método para obtener una persona por ID como DTO
    public async Task<PersonDto> GetPersonByIdAsync(int id)
    {
        if (id <= 0)
        {
            _logger.LogWarning("Se intentó obtener una persona con ID inválido: {PersonId}", id);
            throw new ValidationException("id", "El ID de la persona debe ser mayor que cero");
        }

        try
        {
            var person = await _personData.GetByIdAsync(id);
            if (person == null)
            {
                _logger.LogInformation("No se encontró ninguna persona con ID: {PersonId}", id);
                throw new EntityNotFoundException("Person", id);
            }

            return new PersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber,
                Email = person.Email,
                TypeIndification = person.TypeIndification,
                NumberIndification = person.NumberIndification
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener la persona con ID: {PersonId}", id);
            throw new ExternalServiceException("Base de datos", $"Error al recuperar la persona con ID {id}", ex);
        }
    }

    // Método para crear una persona desde un DTO
    public async Task<PersonDto> CreatePersonAsync(PersonDto personDto)
    {
        try
        {
            ValidatePerson(personDto);

            var person = new Person
            {
                FirstName = personDto.FirstName,
                PhoneNumber = personDto.PhoneNumber
            };

            var personCreada = await _personData.CreateAsync(person);

            return new PersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber,
                Email = person.Email,
                TypeIndification = person.TypeIndification,
                NumberIndification = person.NumberIndification
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear nueva persona: {PersonNombre}", personDto?.FirstName ?? "null");
            throw new ExternalServiceException("Base de datos", "Error al crear la persona", ex);
        }
    }

    // Método para validar el DTO
    private void ValidatePerson(PersonDto personDto)
    {
        if (personDto == null)
        {
            throw new ValidationException("El objeto persona no puede ser nulo");
        }

        if (string.IsNullOrWhiteSpace(personDto.FirstName))
        {
            _logger.LogWarning("Se intentó crear/actualizar una persona con Name vacío");
            throw new ValidationException("Name", "El Name de la persona es obligatorio");
        }
    }
}
