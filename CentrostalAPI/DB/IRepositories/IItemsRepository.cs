using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB.Models;

namespace CentrostalAPI.DB.IRepositories {
    public interface IItemsRepository : IGenericRepository<Item> {
        void changeAmountFromOrder(Order order);
    }
}
