using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentrostalAPI.DTOs {
    public class UserLoginRequestDTO {
        [Required(ErrorMessage = "username is required")]
        public string username { get; set; }

        [Required(ErrorMessage = "password is required")]
        public string password { get; set; }
    }

    public class UserLoginResponseDTO {
        public int userId { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string token { get; set; }
        public DateTime expirationTime { get; set; }
        public bool isAdmin { get; set; }
    }
    public class UserRegistrationDTO {
        [Required(ErrorMessage = "username is required")]
        public string username { get; set; }

        [Required(ErrorMessage = "password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "firstname is required")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "lastname is required")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "email is required")]
        [EmailAddress]
        public string email { get; set; }
    }

    public class UserPublicInfoDTO {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string username { get; set; }
    }
}
