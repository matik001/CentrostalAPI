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
    [Route("item/template")]
    public class ItemsTemplateController : ControllerBase {
        private readonly IUserService _userService;
        private readonly IItemsTemplateService _itemTemplateService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ItemsTemplateController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper, IItemsTemplateService itemTemplateService) {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _itemTemplateService = itemTemplateService;
        }

        [HttpGet]
        public async Task<IActionResult> getAll([FromQuery] string pattern = "") {
            if(pattern == null)
                pattern = "";
            var itemTemplates = (await _unitOfWork.itemTemplates.all(
                a => a.name.ToLower().Contains(pattern.ToLower()),
                includes: new[] { "currents", "steelTypes", "steelTypes.steelType" }));
            var res = _mapper.Map<List<ItemTemplateResponseDTO>>(itemTemplates);
            res = res.Select(x => {
                var sortedCurrents = x.currents.ToList();
                sortedCurrents.Sort();
                x.currents = sortedCurrents;
                return x;
            }).ToList();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> get([FromRoute] int id) {
            var itemTemplate = await _unitOfWork.itemTemplates.getById(id, includes: new[] { "currents", "steelTypes", "steelTypes.steelType" });
            var res = _mapper.Map<ItemTemplateResponseDTO>(itemTemplate);

            var sortedCurrents = res.currents.ToList();
            sortedCurrents.Sort();
            res.currents = sortedCurrents;

            return Ok(res);
        }

        [Authorize(policy: AuthorizationPolicies.AdminOnly)]
        [HttpPost]
        public async Task<IActionResult> create([FromBody] ItemTemplateRequestDTO createdItem) {
            await _itemTemplateService.create(createdItem);
            await _unitOfWork.saveAsync();
            return NoContent();
        }

        [Authorize(policy: AuthorizationPolicies.AdminOnly)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> update([FromRoute] int id, [FromBody] ItemTemplateRequestDTO updateItem) {
            await _itemTemplateService.update(id, updateItem);
            await _unitOfWork.saveAsync();
            return NoContent();
        }

        [Authorize(policy: AuthorizationPolicies.AdminOnly)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> delete([FromRoute] int id) {
            await _itemTemplateService.delete(id);
            await _unitOfWork.saveAsync();
            return NoContent();
        }

        [HttpGet("/item/names")]
        public async Task<IActionResult> getNames([FromQuery] string pattern = "") {
            if(pattern == null)
                pattern = "";
            var items = await _unitOfWork.itemTemplates.all(a => a.name.ToLower().Contains(pattern.ToLower()));
            var names = items.Select(x => x.name).ToArray();
            return Ok(names);
        }



    }
}
