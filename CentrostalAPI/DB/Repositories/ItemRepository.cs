using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB.IRepositories;
using CentrostalAPI.DB.Models;

namespace CentrostalAPI.DB.Repositories {
    public class ItemRepository : GenericRepository<Item>, IItemRepository {
        public ItemRepository(ApplicationDbContext context) : base(context) {
        }
    }
}
