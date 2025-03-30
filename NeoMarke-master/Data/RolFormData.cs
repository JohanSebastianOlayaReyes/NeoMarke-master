using System;
using System.Security.Principal;


public async Task<bool> UpdateAAsync(RolForm rolform)
{
    try
    {
        _context.Set<RolForm>().Update(rolform);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al actualizar: {ex.Message}");
        return false;
    }
}


public async Task<RolForm> CreateAsync(RolForm rolform)
{
    try
    {
        await _context.Set<RolForm>.AddAsync(rolform);
        await _context.SaveChsngesAsync();
        return rolform;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al crear: {ex.Message}");
        throw;
    }
}


public async Task<IEnumerable<rolform>> GetAllAsync()
{
    return await _context.Set<rolform>().ToListAsync();
}

public async Task<RolForm?> GetByIdAsync(int id)
{
    try
    {
        return await _cotext.Set<RolForm>().FindAsync(id);
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
    class RolFormData
    {
        private readonly ApplicationDbContext_context;
        private readonly ILogger _logger;


        public RolFormData(ApplicationDbContext context, ILogger logger)
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
        var rolform = await _context.Set<rolform>().FindAsync(id);
        if (rolform == null)
            return false;

        _context.Set<RolForm>().Remove(rolform);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al eliminar:{ex.Message}");
        return false;
    }
}