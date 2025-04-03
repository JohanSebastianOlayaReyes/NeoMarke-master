using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    class SedeDTO
    {
        public string name { get; set; } = string.Empty;
        public string code_sede { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public int phone_sede { get; set; }
        public string email_sede { get; set; } = string.Empty;
        public bool status { get; set; }

    }
}
