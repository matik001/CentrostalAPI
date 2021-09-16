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
    [Route("order")]
    public class OrdersController : ControllerBase {
        private readonly IUserService _userService;
        private readonly IOrdersService _ordersService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrdersController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper, IOrdersService ordersService) {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _ordersService = ordersService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> getAll() {
            var orders = (await _unitOfWork.orders.all(
                includes: new[] {   "orderingUser",
                                    "status",
                                    "orderItems",
                                    "orderItems.item",
                                    "orderItems.item.steelType",
                },
                orderBy: (query) => query.OrderByDescending(a => a.lastEditedDate)));
            var res = _mapper.Map<List<OrderDTO>>(orders);
            return Ok(res);
        }

        //[HttpGet("{id:int}")]
        //public async Task<IActionResult> get([FromRoute] int id) {
        //    var itemTemplate = await _unitOfWork.itemTemplates.getById(id, includes: new[] { "currents", "steelTypes", "steelTypes.steelType" });
        //    var res = _mapper.Map<ItemTemplateResponseDTO>(itemTemplate);
        //    return Ok(res);
        //}

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> create([FromBody] CreateOrderDTO newOrder) {
            var userId = _userService.getUserId(this);
            await _ordersService.create(userId, newOrder);
            await _unitOfWork.saveAsync();
            return NoContent();
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> update([FromRoute] int id, [FromBody] UpdateOrderDTO order) {
            await _ordersService.update(id, order);
            await _unitOfWork.saveAsync();
            return NoContent();
        }

        [Authorize]
        [HttpPatch("{id:int}/finish")]
        public async Task<IActionResult> finish([FromRoute] int id) {
            await _ordersService.markStatus(id, DB.Repositories.Statuses.executed);
            await _unitOfWork.saveAsync();
            return NoContent();
        }

        [Authorize]
        [HttpPatch("{id:int}/cancel")]
        public async Task<IActionResult> cancel([FromRoute] int id) {
            await _ordersService.markStatus(id, DB.Repositories.Statuses.canceled);
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
