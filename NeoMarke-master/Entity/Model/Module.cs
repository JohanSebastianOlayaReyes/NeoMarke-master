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
		public string CreateDate { get; set; }
		public string UpdateDate { get; set; }
		public string DeleteDate { get; set; }
		public int ForModuleId {get; set; }
		public required ForModule ForModule { get; set; }
	}
}
