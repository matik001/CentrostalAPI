using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentrostalAPI.DTOs {
    public class OrderDTO {
        public int id { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime? lastEditedDate { get; set; }
        public DateTime? executedDate { get; set; }
        public StatusDTO status { get; set; }
        public string orderingPerson { get; set; }
        public bool isSupply { get; set; }
        public ICollection<OrderItemDTO> orderItems { get; set; }
    }
    public class OrderItemDTO {
        public int amountDelta { get; set; }
        public ItemDTO item { get; set; }
    }

    public class CreateOrderItemDTO {
        public int amountDelta { get; set; }
        public int itemId { get; set; }
    }
    public class CreateOrderDTO {
        public bool isSupply { get; set; }
        public ICollection<CreateOrderItemDTO> orderItems { get; set; }
    }
    public class UpdateOrderDTO : CreateOrderDTO { }
}
