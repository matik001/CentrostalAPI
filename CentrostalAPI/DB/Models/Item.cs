using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentrostalAPI.DB.Models {
    public class Item : IHavingId {
        public int id { get; set; }
        public int itemTemplateId { get; set; }
        public ItemTemplate itemTemplate { get; set; }
        public int amount { get; set; }
        public int current { get; set; }
        public bool isOriginal { get; set; }
        public int steelTypeId { get; set; }
        public SteelType steelType { get; set; }
        public ICollection<OrderItem> orderItems { get; set; }
    }
}
