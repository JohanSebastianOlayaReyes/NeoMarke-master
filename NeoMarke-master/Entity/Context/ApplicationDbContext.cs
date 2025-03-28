using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;

namespace Entity.Contexts
{
    ///<summary>
    ///representa el contexto de la base de datos de la aplicacion, proporcionando  configuraciones y metodos 
    ///para la gestion de entidades y consultas personalizadas con Dapper
    ///</summary>
    public class ApplicationDbContext : ApplicationDbContext
    {
        ///<summary>
        ///Configuracion de la aplicacion
        ///</summary>
        protected readonly IConfiguration _configuration;

        ///<summary>
        ///Constructor del contexto de la base de datos
        ///</summary>
        ///<param name="options">Opciones de configuracion para el contexto de base de datos.</param>
        ///<param name="configuration">instancia de IConfiguration para acceder a la configuracion de la aplicacion</param>
        public ApplicationDbContext
    }

}