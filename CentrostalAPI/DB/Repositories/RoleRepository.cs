using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB.IRepositories;
using CentrostalAPI.DB.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentrostalAPI.DB.Repositories {
    public class RoleRepository : GenericRepository<Role>, IRoleRepository {
        public RoleRepository(ApplicationDbContext context) : base(context) {
        }

        public static void seed(EntityTypeBuilder<Role> builder) {
            builder.HasData(
                new Role() { id = 1, name = "admin" },
                new Role() { id = 2, name = "blocked" },
                new Role() { id = 3, name = "chairman" }
            );
        }
        public enum Roles {
            Admin = 1,
            Blocked = 2,
            Chairman = 3
        }
    }
}
