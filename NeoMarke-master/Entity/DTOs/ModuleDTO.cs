using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    class ModuleDTO
    {
        public int Id { get; set; }
        public string active { get; set; }
        public string create_date { get; set; }
        public string update_date { get; set; }
        public string delete_date { get; set; }
    }
}
