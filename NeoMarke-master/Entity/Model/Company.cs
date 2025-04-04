using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Entity.Model
{
	public class Company
	{
		public int Id { get; set; }
		public string CreateAt { get; set; }
		public string UpdateAt { get; set; }
		public string DeleteDate { get; set; }
		public string Description { get; set; }
		public string NameCompany { get; set; } = string.Empty;
		public int PhoneCompany { get; set; }
		public string Locality { get; set; }
		public string EmailCompany { get; set; } = string.Empty;
		public string NitCompany { get; set; }
		public bool Status { get; set; }
        public int IdUser { get; set; }
        public required User User { get; set; } 
        public int IdSede { get; set; }
        public required Sede Sede { get; set; } 
    }
}
