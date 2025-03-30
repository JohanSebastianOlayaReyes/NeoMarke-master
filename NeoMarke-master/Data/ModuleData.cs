using System;
using System.Security.Principal;


public async Task<bool> UpdateAAsync(Module module)
{
    try
    {
        _context.Set<Module>().Update(module);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al actualizar: {ex.Message}");
        return false;
    }
}


public async Task<Module> CreateAsync(Module module)
{
    try
    {
        await _context.Set<Module>.AddAsync(module);
        await _context.SaveChsngesAsync();
        return module;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al crear: {ex.Message}");
        throw;
    }
}


public async Task<IEnumerable<module>> GetAllAsync()
{
    return await _context.Set<module>().ToListAsync();
}

public async Task<Module?> GetByIdAsync(int id)
{
    try
    {
        return await _cotext.Set<Module>().FindAsync(id);
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
    class ModuleData
    {
        private readonly ApplicationDbContext_context;
        private readonly ILogger _logger;


        public ModuleData(ApplicationDbContext context, ILogger logger)
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
        var module = await _context.Set<module>().FindAsync(id);
        if (module == null)
            return false;

        _context.Set<Module>().Remove(module);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al eliminar:{ex.Message}");
        return false;
    }
}