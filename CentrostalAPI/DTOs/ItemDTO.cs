using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentrostalAPI.DTOs {
    public class CreateItemDTO {
        public string name { get; set; }
        public int number { get; set; }
        public int amount { get; set; }
        public int current { get; set; }
        public bool isOriginal { get; set; }
        public string steelType { get; set; }
        public int minStock { get; set; }
    }
    public class UpdateItemDTO : CreateItemDTO { }
    public class ItemDTO : CreateItemDTO {
        public int id { get; set; }
    }
}
