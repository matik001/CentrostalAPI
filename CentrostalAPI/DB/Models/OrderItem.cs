using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB.Models;

namespace CentrostalAPI.DB.Models {
    public class OrderItem : IHavingId {
        public int id { get; set; }
        public int itemId { get; set; }
        public Item item { get; set; }
        public int amountDelta { get; set; }
        public int orderId { get; set; }
        public Order order { get; set; }
        public decimal priceOne { get; set; }

    }
}
