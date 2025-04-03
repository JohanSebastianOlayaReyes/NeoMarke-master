using Entity.Contexts;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class RolFormData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RolFormData> _logger;

        public RolFormData(ApplicationDbContext context, ILogger<RolFormData> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Crear un nuevo RolForm
        public async Task<RolForm> CreateAsync(RolForm rolForm)
        {
            try
            {
                await _context.Set<RolForm>().AddAsync(rolForm);
                await _context.SaveChangesAsync();
                return rolForm;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el RolForm: {ex.Message}");
                throw;
            }
        }

        // Obtener todos los RolForms
        public async Task<IEnumerable<RolForm>> GetAllAsync()
        {
            return await _context.Set<RolForm>().ToListAsync();
        }

        // Obtener un RolForm por ID
        public async Task<RolForm?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<RolForm>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el RolForm con ID {id}: {ex.Message}");
                throw;
            }
        }

        // Actualizar un RolForm
        public async Task<bool> UpdateAsync(RolForm rolForm)
        {
            try
            {
                _context.Set<RolForm>().Update(rolForm);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el RolForm: {ex.Message}");
                return false;
            }
        }

        // Eliminar un RolForm por ID
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var rolForm = await _context.Set<RolForm>().FindAsync(id);
                if (rolForm == null)
                    return false;

                _context.Set<RolForm>().Remove(rolForm);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el RolForm: {ex.Message}");
                return false;
            }
        }
    }
}
