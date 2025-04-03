using System;
using System.collections.Generic;
using System.Ling;
using System.Text;
using System.Threading.Tasks


    namespace Entity.Model
{
	public class RolForm
	{
		public int Id { get; set; }
		public string Permission { get; set; }
		public int Id_Form { get; set; }
		public required Form Form { get; set; }
		public int Id_Rol { get; set;}
		public required Rol Rol { get; set; } 
    }
}
