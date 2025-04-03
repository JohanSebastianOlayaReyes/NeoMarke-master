using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkcore;
using Microsoft.Extension.Logging;

namespace Data
{
    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var Company = await _context.Set<company>().FindAsync(id);
            if (Company == null)
                return false;

            _context.Set<CompanyData>().Remove(company);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar:{ex.Message}");
            return false;
        }
    }

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


    public class CompanyData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public CompanyData(ApplicationDbContext context, ILogger<CompanyData> logger)
        {
            _context = context;
            _logger = (ILogger?)logger;
        }

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
                await _context.Set<Company>().AddAsync(company);
                await _context.SaveChangesAsync();
                return company;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Set<Company>().ToListAsync();
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Company>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener info con id", id);
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var company = await _context.Set<Company>().FindAsync(id);
                if (company == null)
                    return false;

                _context.Set<Company>().Remove(company);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar: {ex.Message}");
                return false;
            }
        }
    }
}

