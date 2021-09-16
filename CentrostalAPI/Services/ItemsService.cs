using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CentrostalAPI.DB;
using CentrostalAPI.DB.Models;
using CentrostalAPI.DTOs;
using CentrostalAPI.HttpErrors;
using CentrostalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CentrostalAPI.IServices {
    public class ItemsService : IItemsService {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ItemsService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task create(CreateItemDTO createdItem) {
            var steelType = await _unitOfWork.steelTypes.one(a => a.typeName == createdItem.steelType);
            if(steelType == null) {
                throw new HttpError(400, "Bad steel type");
            }
            var newItem = _mapper.Map<Item>(createdItem);
            newItem.steelTypeId = steelType.id;

            await _unitOfWork.items.add(newItem);
        }

        public async Task update(int id, UpdateItemDTO itemDto) {
            var item = await _unitOfWork.items.getById(id, attach: true);
            if(item == null) {
                throw new HttpError(400, "Bad item id");
            }
            var steelType = await _unitOfWork.steelTypes.one(a => a.typeName == itemDto.steelType);
            if(steelType == null) {
                throw new HttpError(400, "Bad steel type");
            }
            var newItem = _mapper.Map<UpdateItemDTO, Item>(itemDto, item);
            newItem.steelTypeId = steelType.id;
        }


    }
}
