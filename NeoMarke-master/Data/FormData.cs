using System;
using System.Security.Principal;


public async Task<bool> UpdateAAsync(Form form)
{
    try
    {
        _context.Set<Form>().Update(form);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al actualizar: {ex.Message}");
        return false;
    }
}


public async Task<Form> CreateAsync(Form form)
{
    try
    {
        await _context.Set<Form>.AddAsync(form);
        await _context.SaveChsngesAsync();
        return form;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al crear: {ex.Message}");
        throw;
    }
}


public async Task<IEnumerable<form>> GetAllAsync()
{
    return await _context.Set<form>().ToListAsync();
}

public async Task<Form?> GetByIdAsync(int id)
{
    try
    {
        return await _cotext.Set<Form>().FindAsync(id);
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
    class FormData
    {
        private readonly ApplicationDbContext_context;
        private readonly ILogger _logger;


        public FormData(ApplicationDbContext context, ILogger logger)
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
        var form = await _context.Set<form>().FindAsync(id);
        if (form == null)
            return false;

        _context.Set<Form>().Remove(form);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al eliminar:{ex.Message}");
        return false;
    }
}