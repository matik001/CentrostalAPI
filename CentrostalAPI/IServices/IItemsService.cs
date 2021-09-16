using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB;
using CentrostalAPI.DTOs;
using CentrostalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CentrostalAPI.IServices {
    public interface IItemsService {
        Task create(CreateItemDTO createdItem);
        Task update(int id, UpdateItemDTO itemDto);
    }
}
