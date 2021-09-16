using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB.IRepositories;
using CentrostalAPI.DB.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentrostalAPI.DB.Repositories {
    public class SteelTypeRepository : GenericRepository<SteelType>, ISteelTypeRepository {
        public SteelTypeRepository(ApplicationDbContext context) : base(context) {
        }

        public enum SteelTypesEnum {
            stalMiekka = 1,
            stalMiekkaBavel = 2,
            stalNierdzewna = 3,
            stalNierdzewnaBavel = 4,
            aluminium = 5
        }
        public static void seed(EntityTypeBuilder<SteelType> builder) {
            builder.HasData(
                new SteelType() { id = 1, typeName = "Stal miękka" },
                new SteelType() { id = 2, typeName = "Stal miękka - Bevel" },
                new SteelType() { id = 3, typeName = "Stal nierdzewna" },
                new SteelType() { id = 4, typeName = "Stal nierdzewna - Bevel" },
                new SteelType() { id = 5, typeName = "Aluminium" }
            );
        }
    }
}
