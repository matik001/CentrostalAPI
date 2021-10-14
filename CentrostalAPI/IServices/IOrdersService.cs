using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB;
using CentrostalAPI.DB.Repositories;
using CentrostalAPI.DTOs;
using CentrostalAPI.DB.Models;
using Microsoft.AspNetCore.Mvc;

namespace CentrostalAPI.IServices {
    public interface IOrdersService {
        /// return id
        public Task create(int userId, CreateOrderDTO dto);
        public Task update(User user, int id, UpdateOrderDTO dto);
        public Task cancelOrder(User user, int id);
        public Task changeToNextStatus(User user, int id);
    }
}
