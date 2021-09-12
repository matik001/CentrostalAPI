using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentrostalAPI.DB.Models;

namespace CentrostalAPI.Models {
    public class User : IHavingId {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string passwordSalt { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }

        /// can edit templates
        public bool isAdmin { get; set; }

        /// it doesn't allow to login - but jwt token still works
        public bool isBlocked { get; set; }

        public ICollection<Order> orders { get; set; }

        public override string ToString() {
            return $"{firstName} {lastName}";
        }
    }
}
