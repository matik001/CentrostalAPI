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
using CentrostalAPI.Models;
using Microsoft.AspNetCore.Mvc;

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
                statusId = (int)Statuses.created,
                orderItems = orderItems,
                isSupply = dto.isSupply
            };
            await _unitOfWork.orders.add(newOrder);
        }
        public async Task update(int id, UpdateOrderDTO dto) {
            var orderItems = dto.orderItems.Select(a => new OrderItem() {
                amountDelta = a.amountDelta,
                itemId = a.itemId
            }).ToList();
            var order = await _unitOfWork.orders.getById(id, includes: new[] {
                "orderItems"
            }, attach: true);
            order.isSupply = dto.isSupply;
            order.lastEditedDate = DateTime.UtcNow;
            order.orderItems = orderItems;
        }
        public async Task finishOrder(int id) {
            var order = await _unitOfWork.orders.getById(id, includes: new[]{
                "orderItems",
                "orderItems.item"
            }, attach: true);
            order.executedDate = DateTime.UtcNow;
            order.lastEditedDate = DateTime.UtcNow;


            _unitOfWork.items.changeAmountFromOrder(order);
            order.statusId = (int)(order.isSupply ? Statuses.received : Statuses.executed);
        }
        public async Task cancelOrder(int id) {
            var order = await _unitOfWork.orders.getById(id, includes: new[]{
                "orderItems",
                "orderItems.item"
            }, attach: true);
            order.executedDate = DateTime.UtcNow;
            order.lastEditedDate = DateTime.UtcNow;

            _unitOfWork.items.changeAmountFromOrder(order);
            order.statusId = (int)(Statuses.canceled);
        }

    }
}
