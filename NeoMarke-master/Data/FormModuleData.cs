using System;
using System.Security.Principal;


public async Task<bool> UpdateAAsync(FormModule formmodule)
{
    try
    {
        _context.Set<FormModule>().Update(formmodule);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al actualizar: {ex.Message}");
        return false;
    }
}


public async Task<FormModule> CreateAsync(FormModule formmodule)
{
    try
    {
        await _context.Set<FormModule>.AddAsync(formmodule);
        await _context.SaveChsngesAsync();
        return formmodule;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al crear: {ex.Message}");
        throw;
    }
}


public async Task<IEnumerable<formmodule>> GetAllAsync()
{
    return await _context.Set<formmodule>().ToListAsync();
}

public async Task<FormModule?> GetByIdAsync(int id)
{
    try
    {
        return await _cotext.Set<FormModule>().FindAsync(id);
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
    class FormModuleData
    {
        private readonly ApplicationDbContext_context;
        private readonly ILogger _logger;


        public FormModuleData(ApplicationDbContext context, ILogger logger)
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
        var formmodule = await _context.Set<formmodule>().FindAsync(id);
        if (formmodule == null)
            return false;

        _context.Set<FormModule>().Remove(formmodule);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al eliminar:{ex.Message}");
        return false;
    }
}