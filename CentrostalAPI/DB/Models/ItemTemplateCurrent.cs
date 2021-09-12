using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentrostalAPI.DB.Models {
    public class ItemTemplateCurrent : IHavingId {
        public int id { get; set; }
        public int itemTemplateId { get; set; }
        public ItemTemplate itemTemplate { get; set; }
        public int current { get; set; }
    }
}
