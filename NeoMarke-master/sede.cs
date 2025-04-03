using System;
using System.collections.Generic;
using System.Ling;
using System.Text;
using System.Threading.Tasks


    namespace Entity.Model
{
	public class Sede
	{
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string CodeSede { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneSede { get; set; } = string.Empty;
        public string EmailSede { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}
