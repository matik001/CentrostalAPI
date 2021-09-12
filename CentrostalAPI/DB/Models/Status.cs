using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrostalAPI.DB.Models {
    public class Status : IHavingId {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<Order> orders { get; set; }
    }
}
