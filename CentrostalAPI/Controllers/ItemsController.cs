using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CentrostalAPI.Config;
using CentrostalAPI.DB;
using CentrostalAPI.DB.Models;
using CentrostalAPI.DTOs;
using CentrostalAPI.HttpErrors;
using CentrostalAPI.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentrostalAPI.Controllers {
    [ApiController]
    [Route("item")]
    public class ItemsController : ControllerBase {
        private readonly IUserService _userService;
        private readonly IItemsService itemsService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ItemsController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper, IItemsService itemsService) {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.itemsService = itemsService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> getAll([FromQuery] string pattern = null,
                                                [FromQuery] string steelType = null,
                                                [FromQuery] int? number = null,
                                                [FromQuery] int? current = null,
                                                [FromQuery] bool? isOriginal = null) {

            var items = (await _unitOfWork.items.all(
                a => (pattern == null || a.name.ToLower().Contains(pattern.ToLower())) &&
                    (steelType == null || a.steelType.typeName.ToLower() == steelType.ToLower()) &&
                    (number == null || a.number == number) &&
                    (current == null || a.current == current) &&
                    (isOriginal == null || a.isOriginal == isOriginal)
                ,
                includes: new[] { "steelType" },
                orderBy: (query) => query.OrderBy(x => x.amount)));
            var res = _mapper.Map<List<ItemDTO>>(items);
            return Ok(res);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> get([FromRoute] int id) {
            var item = await _unitOfWork.items.getById(id,
                includes: new[] { "steelType" });
            var res = _mapper.Map<ItemDTO>(item);
            return Ok(res);
        }

        [Authorize(policy: AuthorizationPolicies.AdminOnly)]
        [HttpPost]
        public async Task<IActionResult> create([FromBody] CreateItemDTO createdItem) {
            await itemsService.create(createdItem);
            await _unitOfWork.saveAsync();
            return Ok();
        }

        [Authorize(policy: AuthorizationPolicies.AdminOnly)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> update([FromRoute] int id, [FromBody] UpdateItemDTO item) {
            await itemsService.update(id, item);
            await _unitOfWork.saveAsync();
            return NoContent();
        }


        //[Authorize(policy: AuthorizationPolicies.AdminOnly)]
        //[HttpDelete("{id:int}")]
        //public async Task<IActionResult> delete([FromRoute] int id) {
        //    var itemTemplate = await _unitOfWork.itemTemplates.getById(id, includes: new[] { "currents", "steelTypes", "steelTypes.steelType" });
        //    if(itemTemplate == null) {
        //        throw new HttpError(400, "Wrong id");
        //    }
        //    await _unitOfWork.itemTemplates.delete(itemTemplate);
        //    await _unitOfWork.saveAsync();
        //    return NoContent();
        //}
    }
}
