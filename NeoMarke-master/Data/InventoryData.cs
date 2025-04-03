using Entity.Contexts;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class InventoryData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<InventoryData> _logger;

        public InventoryData(ApplicationDbContext context, ILogger<InventoryData> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Crear un nuevo Inventario
        public async Task<Inventory> CreateAsync(Inventory inventory)
        {
            try
            {
                await _context.Set<Inventory>().AddAsync(inventory);
                await _context.SaveChangesAsync();
                return inventory;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el Inventario: {ex.Message}");
                throw;
            }
        }

        // Obtener todos los Inventarios
        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            return await _context.Set<Inventory>().ToListAsync();
        }

        // Obtener un Inventario por ID
        public async Task<Inventory?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Inventory>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el Inventario con ID {id}: {ex.Message}");
                throw;
            }
        }

        // Actualizar un Inventario
        public async Task<bool> UpdateAsync(Inventory inventory)
        {
            try
            {
                _context.Set<Inventory>().Update(inventory);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el Inventario: {ex.Message}");
                return false;
            }
        }

        // Eliminar un Inventario por ID
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var inventory = await _context.Set<Inventory>().FindAsync(id);
                if (inventory == null)
                    return false;

                _context.Set<Inventory>().Remove(inventory);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el Inventario: {ex.Message}");
                return false;
            }
        }
    }
}
