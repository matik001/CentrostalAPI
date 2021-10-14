using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentrostalAPI.DB.Models {
    public class Order : IHavingId {
        public int id { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime? lastEditedDate { get; set; }
        public DateTime? executedDate { get; set; }
        public int statusId { get; set; }
        public Status status { get; set; }
        public bool isSupply { get; set; }
        public int orderingUserId { get; set; }
        public User orderingUser { get; set; }
        public ICollection<OrderItem> orderItems { get; set; }

    }
}
