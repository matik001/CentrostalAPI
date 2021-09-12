using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentrostalAPI.DB.Models {
    public class SteelType : IHavingId {
        public int id { get; set; }
        public string typeName { get; set; }
        public ICollection<Item> items { get; set; }
        public ICollection<ItemTemplateSteelType> itemTemplateSteelTypes { get; set; }
    }
}
