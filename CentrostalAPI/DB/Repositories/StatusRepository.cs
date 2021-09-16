using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB.IRepositories;
using CentrostalAPI.DB.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentrostalAPI.DB.Repositories {
    public class StatusRepository : GenericRepository<Status>, IStatusRepository {
        public StatusRepository(ApplicationDbContext context) : base(context) {
        }

        public static void seed(EntityTypeBuilder<Status> builder) {
            builder.HasData(
                new Status() { id = 1, name = "zlecone" },
                new Status() { id = 2, name = "zrealizowane" },
                new Status() { id = 3, name = "anulowane" }
            );
        }
    }
    public enum Statuses {
        created = 1,
        executed = 2,
        canceled = 3
    }
}
