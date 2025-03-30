using System;
using System.Security.Principal;


public async Task<bool> UpdateAAsync(Inventory inventory)
{
    try
    {
        _context.Set<Inventory>().Update(inventory);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al actualizar: {ex.Message}");
        return false;
    }
}


public async Task<Inventory> CreateAsync(Inventory inventory)
{
    try
    {
        await _context.Set<Inventory>.AddAsync(inventory);
        await _context.SaveChsngesAsync();
        return inventory;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al crear: {ex.Message}");
        throw;
    }
}


public async Task<IEnumerable<inventory>> GetAllAsync()
{
    return await _context.Set<inventory>().ToListAsync();
}

public async Task<Inventory?> GetByIdAsync(int id)
{
    try
    {
        return await _cotext.Set<Inventory>().FindAsync(id);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error al obtener info con id", id);
        throw;
    }
}

using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkcore;
using Microsoft.Extension.Logging;

namespace Data
{
>
    class InventoryData
    {
        private readonly ApplicationDbContext_context;
        private readonly ILogger _logger;


        public InventoryData(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}

public async Task<bool> DeleteAsync(int id)
{
    try
    {
        var Inventory = await _context.Set<inventory>().FindAsync(id);
        if (Inventory == null)
            return false;

        _context.Set<Inventory>().Remove(inventory);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al eliminar:{ex.Message}");
        return false;
    }
}