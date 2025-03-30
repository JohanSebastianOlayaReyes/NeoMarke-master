using System;
using System.Security.Principal;


public async Task<bool> UpdateAAsync(Person person)
{
    try
    {
        _context.Set<Person>().Update(person);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al actualizar el person: {ex.Message}");
        return false;
    }
}


public async Task<Person> CreateAsync(Person person)
{
    try
    {
        await _context.Set<Person>.AddAsync(person);
        await _context.SaveChsngesAsync();
        return person;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al crear: {ex.Message}");
        throw;
    }
}


public async Task<IEnumerable<person>> GetAllAsync()
{
    return await _context.Set<Person>().ToListAsync();
}

public async Task<Person?> GetByIdAsync(int id)
{
    try
    {
        return await _cotext.Set<Person>().FindAsync(id);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error al obtener rol con ID {RolId}", id);
        throw; //Re-lanza la excepcion ´para q sea manejadas en capas superiores
    }
}

using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkcore;
using Microsoft.Extension.Logging;

namespace Data
{
>
    class PersonData
    {
        private readonly ApplicationDbContext_context;
        private readonly ILogger _logger;


        public PersonData(ApplicationDbContext context, ILogger logger)
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
        var person = await _context.Set<Person>().FindAsync(id);
        if (person == null)
            return false;

        _context.Set<Person>().Remove(person);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al eliminar:{ex.Message}");
        return false;
    }
}