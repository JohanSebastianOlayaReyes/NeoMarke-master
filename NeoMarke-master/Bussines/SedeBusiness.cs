﻿using Data;
using Entity.DTO;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business;

/// <summary>
/// Clase de negocio encargada de la lógica relacionada con las sedes del sistema.
/// </summary>
public class SedeBusiness
{
    private readonly SedeData _sedeData;
    private readonly ILogger _logger;

    public SedeBusiness(SedeData sedeData, ILogger logger)
    {
        _sedeData = sedeData;
        _logger = logger;
    }

    // Método para obtener todas las sedes como DTOs
    public async Task<IEnumerable<SedeDto>> GetAllSedesAsync()
    {
        try
        {
            var sedes = await _sedeData.GetAllAsync();
            var sedesDTO = new List<SedeDto>();

            foreach (var sede in sedes)
            {
                sedesDTO.Add(new SedeDto
                {
                    Id = sede.Id,
                    Name = sede.Name,
                    CodeSede = sede.CodeSede,
                    Address = sede.Address,
                    EmailSede = sede.EmailSede,
                    Status = sede.Status
                });
            }

            return sedesDTO;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todas las sedes");
            throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de sedes", ex);
        }
    }

    // Método para obtener una sede por ID como DTO
    public async Task<SedeDto> GetSedeByIdAsync(int id)
    {
        if (id <= 0)
        {
            _logger.LogWarning("Se intentó obtener una sede con ID inválido: {SedeId}", id);
            throw new ValidationException("id", "El ID de la sede debe ser mayor que cero");
        }

        try
        {
            var sede = await _sedeData.GetByIdAsync(id);
            if (sede == null)
            {
                _logger.LogInformation("No se encontró ninguna sede con ID: {SedeId}", id);
                throw new EntityNotFoundException("Sede", id);
            }

            return new SedeDto
            {
                Id = sede.Id,
                Name = sede.Name,
                CodeSede = sede.CodeSede,
                Address = sede.Address,
                EmailSede = sede.EmailSede,
                Status = sede.Status
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener la sede con ID: {SedeId}", id);
            throw new ExternalServiceException("Base de datos", $"Error al recuperar la sede con ID {id}", ex);
        }
    }

    // Método para crear una sede desde un DTO
    public async Task<SedeDto> CreateSedeAsync(SedeDto sedeDto)
    {
        try
        {
            ValidateSede(sedeDto);

            var sede = new Sede
            {
                Name = sedeDto.Name,

            };

            var sedeCreada = await _sedeData.CreateAsync(sede);

            return new SedeDto
            {
                Id = sede.Id,
                Name = sede.Name,
                CodeSede = sede.CodeSede,
                Address = sede.Address,
                EmailSede = sede.EmailSede,
                Status = sede.Status
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear nueva sede: {SedeNombre}", sedeDto?.Name ?? "null");
            throw new ExternalServiceException("Base de datos", "Error al crear la sede", ex);
        }
    }

    // Método para validar el DTO
    private void ValidateSede(SedeDto sedeDto)
    {
        if (sedeDto == null)
        {
            throw new ValidationException("El objeto sede no puede ser nulo");
        }

        if (string.IsNullOrWhiteSpace(sedeDto.Name))
        {
            _logger.LogWarning("Se intentó crear/actualizar una sede con Name vacío");
            throw new ValidationException("Name", "El Name de la sede es obligatorio");
        }
    }
}
