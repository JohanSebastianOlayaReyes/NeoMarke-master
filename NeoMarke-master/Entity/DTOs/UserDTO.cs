using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    class UserDTO
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string createdAt { get; set; }
        public string deletedAt { get; set; }
        public string status { get; set; }
        public string Company_id_company { get; set; }
    }
}
