using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    class CompanyDTO
    {
        public string Description { get; set; } = string.Empty;
        public string NameCompany { get; set; } = string.Empty;
        public int PhoneCompany { get; set; } = 0;
        public string Locality { get; set; } = string.Empty;
        public string EmailCompany { get; set; } = string.Empty;
        public string NitCompany { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}
