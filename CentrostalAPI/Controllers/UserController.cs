using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CentrostalAPI.DB;
using CentrostalAPI.DTOs;
using CentrostalAPI.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentrostalAPI.Controllers {
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUserService userService, IUnitOfWork unitOfWork) {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> login([FromBody] UserLoginRequestDTO loginData) {
            if(loginData == null)
                return BadRequest("Brak danych do logowania");
            var loginResponse = await _userService.login(loginData);
            if(loginResponse == null) {
                return BadRequest("Niepoprawne dane logowania");
            }

            return Ok(loginResponse);
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> register([FromBody] UserRegistrationDTO registrationData) {
            await _userService.register(registrationData);

            var loginResponse = await _userService.login(new UserLoginRequestDTO() {
                username = registrationData.username,
                password = registrationData.password
            });
            if(loginResponse == null) {
                return BadRequest("Invalid credentials");
            }

            return Ok(loginResponse);
        }
    }
}
