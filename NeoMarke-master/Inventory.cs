using System;
using System.collections.Generic;
using System.Ling;
using System.Text;
using System.Threading.Tasks


    namespace Entity.Model
{
        public class Inventory
        {
            public int Id { get; set; } 
            public string StatusPrevious { get; set; } = string.Empty;
            public string StatusNew { get; set; } = string.Empty;
            public string Observations { get; set; } = string.Empty;
            public string CreateAt { get; set; }
            public string DeleteAt { get; set; }
            public string Description { get; set; } = string.Empty;
            public string ZoneItem { get; set; } = string.Empty;
            public int IdItem { get; set; }
            public required Item Item { get; set; }
            public int IdUser { get; set; }
            public required User User { get; set; }
        }

}
