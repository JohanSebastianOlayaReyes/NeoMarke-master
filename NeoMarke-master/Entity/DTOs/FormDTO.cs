using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    class FormDTO
    {
        public int id { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string createdAt { get; set; }
        public string update_date { get; set; }
        public string deleteAt { get; set; }
    }
}
