using System;
using System.collections.Generic;
using System.Ling;
using System.Text;
using System.Threading.Tasks


    namespace Entity.Model
{
	public class Company
	{
		public int Id { get; set; }
		public string CreateAt { get; set; }
		public string UpdateAt { get; set; }
		public string Delete_date { get; set; }
		public string Description { get; set; }
		public string Name_Company { get; set; } = string.Empty;
		public int Phone_Company { get; set; }
		public string Locality { get; set; }
		public string Email_Company { get; set; } = string.Empty;
		public string Nit_Company { get; set; }
		public bool status { get; set; }
        public int IdUser { get; set; }
        public required User User { get; set; } 
        public int IdSede { get; set; }
        public required Sede Sede { get; set; } 
    }
}
