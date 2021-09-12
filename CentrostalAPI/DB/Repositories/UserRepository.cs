using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB.IRepositories;
using CentrostalAPI.DB.Models;
using CentrostalAPI.Models;

namespace CentrostalAPI.DB.Repositories {
    public class UserRepository : GenericRepository<User>, IUserRepository {
        public UserRepository(ApplicationDbContext context) : base(context) {
        }
    }
}
