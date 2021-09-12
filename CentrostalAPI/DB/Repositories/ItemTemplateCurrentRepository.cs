using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB.IRepositories;
using CentrostalAPI.DB.Models;

namespace CentrostalAPI.DB.Repositories {
    public class ItemTemplateCurrentRepository : GenericRepository<ItemTemplateCurrent>, IItemTemplateCurrentRepository {
        public ItemTemplateCurrentRepository(ApplicationDbContext context) : base(context) {
        }
    }
}
