using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentrostalAPI.DB.Models {
    public class Role : IHavingId {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<UserRole> userRoles { get; set; }

    }
}
