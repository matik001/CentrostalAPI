﻿using System;
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

        public OrdersService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task create(int userId, CreateOrderDTO dto) {
            var orderItems = dto.orderItems.Select(a => new OrderItem() {
                amountDelta = a.amountDelta,
                itemId = a.itemId
            }).ToList();
            var newOrder = new Order() {
                createdDate = DateTime.UtcNow,
                orderingUserId = userId,
                statusId = StatusId.created,
                orderItems = orderItems
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
            order.lastEditedDate = DateTime.UtcNow;
            order.orderItems = orderItems;
        }

    }
}
