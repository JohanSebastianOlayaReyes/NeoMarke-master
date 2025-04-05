using Entity.Contexts;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class CategoryData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CategoryData> _logger;

        public CategoryData(ApplicationDbContext context, ILogger<CategoryData> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Crear una nueva Categoría
        public async Task<Category> CreateAsync(Category category)
        {
            try
            {
                await _context.Set<Category>().AddAsync(category);
                await _context.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear la Categoría: {ex.Message}");
                throw;
            }
        }

        // Obtener todas las Categorías
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Set<Category>().ToListAsync();
        }

        // Obtener una Categoría por ID
        public async Task<Category?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Category>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener la Categoría con ID {id}: {ex.Message}");
                throw;
            }
        }

        // Actualizar una Categoría
        public async Task<bool> UpdateAsync(Category category)
        {
            try
            {
                _context.Set<Category>().Update(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar la Categoría: {ex.Message}");
                return false;
            }
        }

        // Eliminar una Categoría por ID
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var category = await _context.Set<Category>().FindAsync(id);
                if (category == null)
                    return false;

                _context.Set<Category>().Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar la Categoría: {ex.Message}");
                return false;
            }
        }
    }
}
