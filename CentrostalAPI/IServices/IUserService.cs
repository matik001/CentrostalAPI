using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DTOs;
using CentrostalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CentrostalAPI.IServices {
    public interface IUserService {
        Task<UserLoginResponseDTO> login(UserLoginRequestDTO loginRequest);
        Task register(UserRegistrationDTO registrationData);

        Task<User> getUser(ControllerBase controller,
            IEnumerable<string> includes = null, bool attach = false);

        int getUserId(ControllerBase controller);
    }
}
