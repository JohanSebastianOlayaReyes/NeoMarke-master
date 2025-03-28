using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    class CompanyDTO
    {

        public string createAt { get; set; }
        public string deleteAt { get; set; }
        public string update_date { get; set; }
        public string description { get; set; }
        public string name_company { get; set; }
        public int phone_company { get; set; }
        public string locality { get; set; }
        public string email_company { get; set; }
        public string nit_company { get; set; }
        public string status { get; set; }
    }
}
