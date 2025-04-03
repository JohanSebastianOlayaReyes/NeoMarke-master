using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkcore;
using Microsoft.Extension.Logging;

namespace Data
{

    ///<summary>
    ///Actualiza un rol existente en la base de datos.
    /// </summary>
    /// <param name="rol">objeto con la informacion actualizada</param>
    /// <returns>True si la operacion fue exitosa, False en caso contrario</returns>
    public async Task<bool> UpdateAAsync(Rol rol)
{
    try
    {
        _context.Set<Rol>().Update(rol);
        await _context.SaveChangesAsync();
        return true;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al actualizar el rol: {ex.Message}");
        return false;
    }
}

///<summary>
///Crea un nuevo rol en labase de datos.
/// </summary>
/// <param name="rol">Instancia del rol a crear.</param>
/// <returns>El rol creado.</returns>
public async Task<Rol>CreateAsync(Rol rol)
{
    try
    {
        await _context.Set<Rol>.AddAsync(rol);
        await _context.SaveChsngesAsync();
        return rol;
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error al crear el rol: {ex.Message}");
        throw;
    }
}

///<summary>
///Obtiene todos los roles almacenados en la base de datos.
///</summary>
///<returns>Lista de roles.</returns>
public async Task<IEnumerable<rol>> GetAllAsync()
{
    return await _context.Set<Rol>().ToListAsync();
}

public async Task<Rol?> GetByIdAsync(int id)
{
    try
    {
        return await _cotext.Set<Rol>().FindAsync(id);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error al obtener rol con ID {RolId}", id);
        throw; //Re-lanza la excepcion ´para q sea manejadas en capas superiores
    }
}


    ///<summary>
    ///repositorio encargad de la gestion de la entidad Rol en lka base de datos 
    ///</summary>
    class RolData
    {
        private readonly ApplicationDbContext_context;
        private readonly ILogger _logger;

        ///<summary>
        ///Constructor que recibe el contexto de base de datos.
        ///</summary>
        ///<param  name="context">Instancia de <see cref="ApplicationDbContext"/> para la conexion con la base de datos.</param>
        public RolData(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}

