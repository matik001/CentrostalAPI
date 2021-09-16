using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB;
using CentrostalAPI.DB.Repositories;
using CentrostalAPI.DTOs;
using CentrostalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CentrostalAPI.IServices {
    public interface IOrdersService {
        /// return id
        public Task create(int userId, CreateOrderDTO dto);
        public Task update(int id, UpdateOrderDTO dto);
        public Task markStatus(int id, Statuses status);
    }
}
