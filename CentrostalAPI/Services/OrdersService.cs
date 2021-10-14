using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CentrostalAPI.DB;
using CentrostalAPI.DB.Models;
using CentrostalAPI.DB.Repositories;
using CentrostalAPI.DTOs;
using CentrostalAPI.HttpErrors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CentrostalAPI.DB.Models.Role;
using static CentrostalAPI.DB.Repositories.RoleRepository;

namespace CentrostalAPI.IServices {
    public class OrdersService : IOrdersService {
        IUnitOfWork _unitOfWork { get; set; }
        IMapper _mapper { get; set; }

        public OrdersService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task create(int userId, CreateOrderDTO dto) {
            var orderItems = dto.orderItems.Select(a => new OrderItem() {
                amountDelta = a.amountDelta,
                itemId = a.itemId
            }).ToList();
            var newOrder = new Order() {
                createdDate = DateTime.UtcNow,
                lastEditedDate = DateTime.UtcNow,
                orderingUserId = userId,
                statusId = (dto.isSupply ? (int)Statuses.editableSupply : (int)Statuses.editableGiving),
                orderItems = orderItems,
                isSupply = dto.isSupply
            };
            await _unitOfWork.orders.add(newOrder);
        }
        public async Task update(User user, int id, UpdateOrderDTO dto) {
            var orderItems = dto.orderItems.Select(a => new OrderItem() {
                amountDelta = a.amountDelta,
                itemId = a.itemId
            }).ToList();
            var order = await _unitOfWork.orders.getById(id, includes: new[] {
                "orderItems",
                "status"
            }, attach: true);
            bool canEdit = order.status.canAnyoneEdit
                || (user.userRoles.Any(a => a.roleId == (int)Roles.Admin) && order.status.canAdminEdit)
                || (user.userRoles.Any(a => a.roleId == (int)Roles.Chairman) && order.status.canChairmanEdit);
            if(!canEdit)
                throw new HttpError(StatusCodes.Status403Forbidden, "You are not allowed to edit this order");

            order.isSupply = dto.isSupply;
            order.lastEditedDate = DateTime.UtcNow;
            order.orderItems = orderItems;
        }
        public async Task changeToNextStatus(User user, int id) {
            var order = await _unitOfWork.orders.getById(id, includes: new[]{
                "orderItems",
                "orderItems.item",
                "status"
            }, attach: true);

            bool canChangeStatus = order.status.canAnyoneChangeStatus
                || (user.userRoles.Any(a => a.roleId == (int)Roles.Admin) && order.status.canAdminChangeStatus)
                || (user.userRoles.Any(a => a.roleId == (int)Roles.Chairman) && order.status.canChairmanChangeStatus)
                || order.status.nextStatusId == null;
            if(!canChangeStatus)
                throw new HttpError(StatusCodes.Status403Forbidden, "You are not allowed to change status in this order");

            var nextStatus = await _unitOfWork.statuses.getById(order.status.nextStatusId.Value);

            order.statusId = nextStatus.id;
            order.executedDate = DateTime.UtcNow;
            order.lastEditedDate = DateTime.UtcNow;

            if(nextStatus.shouldUpdateAmount)
                _unitOfWork.items.changeAmountFromOrder(order);
        }
        public async Task cancelOrder(User user, int id) {
            var order = await _unitOfWork.orders.getById(id, includes: new[]{
                "orderItems",
                "orderItems.item",
                "status"
            }, attach: true);

            bool canCancelStatus = order.status.canAnyoneCancel
                || (user.userRoles.Any(a => a.roleId == (int)Roles.Admin) && order.status.canAdminCancel)
                || (user.userRoles.Any(a => a.roleId == (int)Roles.Chairman) && order.status.canChairmanCancel)
                || order.status.nextStatusId == null;
            if(!canCancelStatus)
                throw new HttpError(StatusCodes.Status403Forbidden, "You are not allowed to change status in this order");


            order.executedDate = DateTime.UtcNow;
            order.lastEditedDate = DateTime.UtcNow;

            order.statusId = (int)(Statuses.canceled);
        }

    }
}
