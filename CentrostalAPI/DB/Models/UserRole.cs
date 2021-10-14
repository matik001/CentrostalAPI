using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentrostalAPI.DB.Models;

namespace CentrostalAPI.DB.Models {
    public class UserRole : IHavingId {
        public int id { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public int roleId { get; set; }
        public Role role { get; set; }
    }
}
