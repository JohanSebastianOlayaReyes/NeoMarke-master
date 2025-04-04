using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    class SedeDTO
    {
        public string Name { get; set; } = string.Empty;
        public string CodeSede { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int PhoneSede { get; set; }
        public string EmailSede { get; set; } = string.Empty;
        public bool Status { get; set; }

    }
}
