using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CentrostalAPI.DB;
using CentrostalAPI.DTOs;
using CentrostalAPI.Helpers;
using CentrostalAPI.HttpErrors;
using CentrostalAPI.IServices;
using CentrostalAPI.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CentrostalAPI.DB.Models.Role;
using static CentrostalAPI.DB.Repositories.RoleRepository;

namespace CentrostalAPI.Services {
    public class UserService : IUserService {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper) {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task register(UserRegistrationDTO registrationData) {
            var existingUser = await _unitOfWork.users.one(u =>
                u.username == registrationData.username ||
                u.email == registrationData.email);
            if(existingUser != null) {
                bool sameEmail = existingUser.email == registrationData.email;
                throw new HttpError((int)HttpStatusCode.Conflict,
                    $"{(sameEmail ? "email" : "username")} already exists");
            }
            var newUser = _mapper.Map<User>(registrationData);
            newUser.passwordSalt = HashingHelper.genSalt();
            newUser.password = HashingHelper.hashUsingPbkdf2(newUser.password, newUser.passwordSalt);
            await _unitOfWork.users.add(newUser);
            await _unitOfWork.saveAsync();
        }
        public async Task<UserLoginResponseDTO> login(UserLoginRequestDTO loginRequest) {
            var user = await _unitOfWork.users.one(u =>
                u.username == loginRequest.username || u.email == loginRequest.username,
                new[] { "userRoles.role" });

            if(user == null || user.userRoles.Any(a => a.roleId == (int)Roles.Blocked)) {
                return null;
            }

            var passwordHash = HashingHelper.hashUsingPbkdf2(loginRequest.password, user.passwordSalt);

            if(user.password != passwordHash) {
                return null;
            }

            var token = await Task.Run(() => JwtHelper.generateToken(user));

            return new UserLoginResponseDTO() {
                username = user.username,
                firstName = user.firstName,
                lastName = user.lastName,
                token = token,
                expirationTime = JwtHelper.getNewExpirationTime(),
                userId = user.id,
                roles = user.userRoles.Select(a => a.role.name).ToList()
            };
        }

        public async Task<User> getUser(ControllerBase controller,
            IEnumerable<string> includes = null, bool attach = false) {
            var user = await _unitOfWork.users.getById(getUserId(controller), includes, attach);
            if(user == null) {
                throw new HttpError(StatusCodes.Status401Unauthorized);
            }

            return user;
        }

        public int getUserId(ControllerBase controller) {
            try {
                var userId = int.Parse(controller.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                return userId;
            }
            catch(Exception e) {
                throw new HttpError(StatusCodes.Status401Unauthorized);
            }
        }
    }
}
