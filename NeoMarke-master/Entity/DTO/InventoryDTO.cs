using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    class InventoryDTO
    {
        public bool StatusPrevious { get; set; }
        public bool StatusNew { get; set; }
        public string Observations { get; set; } = string.Empty;

        public string ZoneItem {  get; set; }

    }
}
