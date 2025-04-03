using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    class CompanyDTO
    {
        public string description { get; set; } = string.Empty;
        public string name_company { get; set; } = string.Empty;
        public int phone_company { get; set; } = 0;
        public string locality { get; set; } = string.Empty;
        public string email_company { get; set; } = string.Empty;
        public string nit_company { get; set; } = string.Empty;
        public bool status { get; set; }
    }
}
