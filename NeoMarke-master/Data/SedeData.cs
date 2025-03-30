using System;
using System.Security.Principal;


public async Task<bool> UpdateAAsync(Sede sede)
{
    try
    {
        _context.Set<Sede>().Update(sede);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al actualizar: {ex.Message}");
        return false;
    }
}


public async Task<Sede> CreateAsync(Sede sede)
{
    try
    {
        await _context.Set<Sede>.AddAsync(sede);
        await _context.SaveChsngesAsync();
        return sede;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al crear: {ex.Message}");
        throw;
    }
}


public async Task<IEnumerable<sede>> GetAllAsync()
{
    return await _context.Set<sede>().ToListAsync();
}

public async Task<Sede?> GetByIdAsync(int id)
{
    try
    {
        return await _cotext.Set<Sede>().FindAsync(id);
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
    class SedeData
    {
        private readonly ApplicationDbContext_context;
        private readonly ILogger _logger;


        public SedeData(ApplicationDbContext context, ILogger logger)
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
        var Sede = await _context.Set<sede>().FindAsync(id);
        if (Sede == null)
            return false;

        _context.Set<Sede>().Remove(sede);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al eliminar:{ex.Message}");
        return false;
    }
}