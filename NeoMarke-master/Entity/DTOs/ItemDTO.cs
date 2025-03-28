using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    class ItemDTO
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string deletedAt { get; set; }
    }
}
