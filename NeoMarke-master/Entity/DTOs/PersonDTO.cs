using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    class PersonDTO
    {
        public string first_name { get; set; } = string.Empty;
        public string last_name { get; set; } = string.Empty;
        public int phone_number { get; set; }
        public string email { get; set; } = string.Empty;
        public string type_indification { get; set; }
        public int number_indification { get; set; }
    }
}
