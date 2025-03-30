using System;
using System.Security.Principal;


public async Task<bool> UpdateAAsync(User user)
{
    try
    {
        _context.Set<User>().Update(user);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al actualizar el person: {ex.Message}");
        return false;
    }
}


public async Task<User> CreateAsync(User user)
{
    try
    {
        await _context.Set<User>.AddAsync(user);
        await _context.SaveChsngesAsync();
        return user;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al crear: {ex.Message}");
        throw;
    }
}


public async Task<IEnumerable<user>> GetAllAsync()
{
    return await _context.Set<user>().ToListAsync();
}

public async Task<User?> GetByIdAsync(int id)
{
    try
    {
        return await _cotext.Set<User>().FindAsync(id);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error al obtener user con id", id);
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
    class UserData
    {
        private readonly ApplicationDbContext_context;
        private readonly ILogger _logger;


        public UserData(ApplicationDbContext context, ILogger logger)
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
        var user = await _context.Set<user>().FindAsync(id);
        if (user == null)
            return false;

        _context.Set<User>().Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al eliminar:{ex.Message}");
        return false;
    }
}