using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    class SedeDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code_sede { get; set; }
        public string address { get; set; }
        public int phone_sede { get; set; }
        public string email_sede { get; set; }
        public string status { get; set; }
        public string createAt { get; set; }
        public string deleteAt { get; set; }
        public string update_date { get; set; }
    }
}
