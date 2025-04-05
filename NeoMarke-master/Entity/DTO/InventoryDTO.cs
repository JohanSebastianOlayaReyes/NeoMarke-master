using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public  class InventoryDto
    {
        public string ProductName { get; set; } = string.Empty;
        public string StatusPrevious { get; set; }
        public string StatusNew { get; set; }
        public string Observations { get; set; } = string.Empty;

        public string ZoneItem {  get; set; }
        public int Id { get; set; }
    }
}
