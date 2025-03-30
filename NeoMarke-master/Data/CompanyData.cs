using System;
using System.Security.Principal;


public async Task<bool> UpdateAAsync(Company company)
{
    try
    {
        _context.Set<Company>().Update(company);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al actualizar: {ex.Message}");
        return false;
    }
}


public async Task<Company> CreateAsync(Company company)
{
    try
    {
        await _context.Set<Company>.AddAsync(company);
        await _context.SaveChsngesAsync();
        return company;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al crear: {ex.Message}");
        throw;
    }
}


public async Task<IEnumerable<company>> GetAllAsync()
{
    return await _context.Set<company>().ToListAsync();
}

public async Task<cCmpany?> GetByIdAsync(int id)
{
    try
    {
        return await _cotext.Set<Company>().FindAsync(id);
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
    class CompanyData
    {
        private readonly ApplicationDbContext_context;
        private readonly ILogger _logger;


        public CompanyData(ApplicationDbContext context, ILogger logger)
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
        var Company = await _context.Set<company>().FindAsync(id);
        if (Company == null)
            return false;

        _context.Set<Company>().Remove(company);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al eliminar:{ex.Message}");
        return false;
    }
}