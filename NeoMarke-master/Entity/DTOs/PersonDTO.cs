using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string second_name { get; set; }
        public string first_last_name { get; set; }
        public string second_last_name { get; set; }
        public int phone_number { get; set; }
        public string email { get; set; }
        public string type_indification { get; set; }
        public int number_indification { get; set; }
    }
}
