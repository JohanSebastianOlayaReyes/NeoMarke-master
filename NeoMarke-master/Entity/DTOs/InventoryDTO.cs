using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    class InventoryDTO
    {
        public int Id { get; set; }
        public string statusPrevious { get; set; }
        public string statusNew { get; set; }
        public string observations { get; set; }
        public string createAt { get; set; }
        public string deleteAt { get; set; }
        public string description { get; set; }
        public string zone_item {  get; set; }

    }
}
