using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CentrostalAPI.Config;
using CentrostalAPI.DB;
using CentrostalAPI.DTOs;
using CentrostalAPI.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentrostalAPI.Controllers {
    [ApiController]
    [Route("steel")]
    public class SteelTypesController : ControllerBase {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public SteelTypesController(IUserService userService, IUnitOfWork unitOfWork) {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> getAll() {
            var seelTypes = await _unitOfWork.steelTypes.all();

            return Ok(seelTypes.Select(a => a.typeName).ToArray());
        }

        [Authorize(policy: AuthorizationPolicies.AdminOnly)]
        [HttpPost]
        public async Task<IActionResult> add([FromBody] string steelName) {
            await _unitOfWork.steelTypes.add(new DB.Models.SteelType() { typeName = steelName });
            await _unitOfWork.saveAsync();
            return Ok();
        }

        [Authorize(policy: AuthorizationPolicies.AdminOnly)]
        [HttpDelete]
        public async Task<IActionResult> delete([FromBody] string steelName) {
            var toDelete = await _unitOfWork.steelTypes.one(a => a.typeName == steelName);
            if(toDelete == null) {
                return BadRequest("steel name doesn't exist");
            }
            await _unitOfWork.steelTypes.delete(toDelete.id);
            await _unitOfWork.saveAsync();
            return Ok();
        }



    }
}
