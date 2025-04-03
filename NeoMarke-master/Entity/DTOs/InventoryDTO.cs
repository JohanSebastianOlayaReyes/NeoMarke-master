using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    class InventoryDTO
    {
        public bool statusPrevious { get; set; }
        public bool statusNew { get; set; }
        public string observations { get; set; } = string.Empty;

        public string zone_item {  get; set; }

    }
}
