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
    public interface IItemsTemplateService {
        /// return id
        public Task create(ItemTemplateRequestDTO dto);
        public Task update(int id, ItemTemplateRequestDTO dto);
        public Task delete(int id);
    }
}
