using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Entity.Model
{
	public class Module
	{
		public int Id { get; set; }
		public bool Active { get; set; }
		public string Create_Date { get; set; }
		public string Update_Date { get; set; }
		public string Delete_Date { get; set; }
		public int ForModuleId {get; set; }
		public required ForModule ForModule { get; set; }
	}
}
