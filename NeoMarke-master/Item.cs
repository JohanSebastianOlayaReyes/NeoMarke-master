using System;
using System.collections.Generic;
using System.Ling;
using System.Text;
using System.Threading.Tasks


    namespace Entity.Model
{
	public class Item
	{
        public int Id { get; set; }  // Se asume que id_item es la clave primaria
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CreateAt { get; set; }
        public string DeleteAt { get; set; }
        public string UpdateAt { get; set; }
        public int IdImageItem { get; set; }
        public required ImageItem ImageItem { get; set; }
        public int IdInventory { get; set; }
        public required Inventory Inventory { get; set; }
        public int IdCategory { get; set; }
        public required Category Category { get; set; }
    }
}
