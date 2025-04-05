using Entity.Contexts;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class ItemData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ItemData> _logger;

        public ItemData(ApplicationDbContext context, ILogger<ItemData> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Crear un nuevo Item
        public async Task<Item> CreateAsync(Item item)
        {
            try
            {
                await _context.Set<Item>().AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el Item: {ex.Message}");
                throw;
            }
        }

        // Obtener todos los Items
        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Set<Item>().ToListAsync();
        }

        // Obtener un Item por ID
        public async Task<Item?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Item>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el Item con ID {id}: {ex.Message}");
                throw;
            }
        }

        // Actualizar un Item
        public async Task<bool> UpdateAsync(Item item)
        {
            try
            {
                _context.Set<Item>().Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el Item: {ex.Message}");
                return false;
            }
        }

        // Eliminar un Item por ID
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var item = await _context.Set<Item>().FindAsync(id);
                if (item == null)
                    return false;

                _context.Set<Item>().Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el Item: {ex.Message}");
                return false;
            }
        }
    }
}
