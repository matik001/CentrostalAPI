using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentrostalAPI.DB.Models {
    public class ItemTemplate : IHavingId {
        public int id { get; set; }
        public string name { get; set; }
        public int number { get; set; }

        public ICollection<Item> items { get; set; }
        public ICollection<ItemTemplateCurrent> currents { get; set; }
        public ICollection<ItemTemplateSteelType> steelTypes { get; set; }
    }
}
