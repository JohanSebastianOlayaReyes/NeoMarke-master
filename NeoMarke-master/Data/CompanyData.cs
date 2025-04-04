using Entity.Contexts;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data
{
    public class CompanyData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CompanyData> _logger;

        public CompanyData(ApplicationDbContext context, ILogger<CompanyData> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Crear una nueva Company
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
                _logger.LogError($"Error al crear la Company: {ex.Message}");
                throw;
            }
        }

        // Obtener todas las Companies
        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Set<Company>().ToListAsync();
        }

        // Obtener una Company por ID
        public async Task<Company?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Company>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener la Company con ID {id}: {ex.Message}");
                throw;
            }
        }

        // Actualizar una Company
        public async Task<bool> UpdateAsync(Company company)
        {
            try
            {
                _context.Set<Company>().Update(company);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar la Company: {ex.Message}");
                return false;
            }
        }

        // Eliminar una Company por ID
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
                _logger.LogError($"Error al eliminar la Company: {ex.Message}");
                return false;
            }
        }
    }
}
