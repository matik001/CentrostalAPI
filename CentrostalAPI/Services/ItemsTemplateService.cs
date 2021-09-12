using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB;
using CentrostalAPI.DB.Models;
using CentrostalAPI.DTOs;
using CentrostalAPI.HttpErrors;
using CentrostalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CentrostalAPI.IServices {
    public class ItemsTemplateService : IItemsTemplateService {

        private readonly IUnitOfWork _unitOfWork;

        public ItemsTemplateService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task createNewItems(ItemTemplate template) {
            if(template.items == null) {
                template.items = new List<Item>();
            }
            var items = template.items;
            foreach(var current in template.currents) {
                foreach(var steelType in template.steelTypes) {
                    foreach(var isOrignal in new[] { true, false }) {
                        var item = items.FirstOrDefault(a => a.current == current.current
                                        && a.steelTypeId == steelType.steelTypeId
                                        && a.isOriginal == isOrignal);
                        if(item == null) {
                            var newItem = new Item() {
                                amount = 0,
                                current = current.current,
                                isOriginal = isOrignal,
                                steelTypeId = steelType.steelTypeId,
                            };
                            template.items.Add(newItem);
                        }
                    }
                }
            }
        }

        public async Task create(ItemTemplateRequestDTO dto) {
            var newSteelTypes = await _unitOfWork.steelTypes.all(a => dto.steelTypes.Contains(a.typeName));
            var itemTemplateSteels = newSteelTypes.Select(a => new ItemTemplateSteelType() { steelTypeId = a.id }).ToList();
            var itemTemplateCurrents = dto.currents.Select(x => new ItemTemplateCurrent() { current = x }).ToList();
            var newItemTemplate = new ItemTemplate() {
                currents = itemTemplateCurrents,
                steelTypes = itemTemplateSteels,
                number = dto.number,
                name = dto.name
            };
            await createNewItems(newItemTemplate);
            await _unitOfWork.itemTemplates.add(newItemTemplate);
        }
        public async Task update(int id, ItemTemplateRequestDTO dto) {
            var updatedItemTemplate = await _unitOfWork.itemTemplates.getById(id, includes: new[] {
                 "currents", "steelTypes", "steelTypes.steelType", "items" }, attach: true);

            if(updatedItemTemplate == null) {
                throw new HttpError(400, "Wrong id");
            }

            var newSteelTypes = await _unitOfWork.steelTypes.all(a => dto.steelTypes.Contains(a.typeName));
            var itemTemplateSteels = newSteelTypes.Select(a => new ItemTemplateSteelType() { steelTypeId = a.id }).ToList();
            var itemTemplateCurrents = dto.currents.Select(x => new ItemTemplateCurrent() { current = x }).ToList();

            updatedItemTemplate.name = dto.name;
            updatedItemTemplate.number = dto.number;
            updatedItemTemplate.currents = itemTemplateCurrents;
            updatedItemTemplate.steelTypes = itemTemplateSteels;
            await createNewItems(updatedItemTemplate);
        }
        public async Task delete(int id) {
            var itemTemplate = await _unitOfWork.itemTemplates.getById(id, includes: new[] { "currents", "steelTypes", "steelTypes.steelType" });
            if(itemTemplate == null) {
                throw new HttpError(400, "Wrong id");
            }
            await _unitOfWork.itemTemplates.delete(itemTemplate);
        }

    }
}
