using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Entity.Model
	{
		public class User
		{
			public int Id { get; set; }
			public string UserName { get; set; } = string.Empty;
			public string Password { get; set; } = string.Empty;
			public string CreateAt { get; set; }
			public string Status { get; set; }
			public int CompanyIdCompany { get; set; }
			public required Company Company { get; set; }
			public int PersonId { get; set; }
			public required Person Person { get; set; }
			public int IdInventoy { get; set; }
			public required Inventory Inventory { get; set; }
			public int IdRol {  get; set; }
			public required Rol Rol { get; set; }
		}
	}
