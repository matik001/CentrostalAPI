﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB.IRepositories;

namespace CentrostalAPI.DB {
    public interface IUnitOfWork : IDisposable {
        IItemRepository items { get; }
        IItemTemplateRepository itemTemplates { get; }
        IItemTemplateCurrentRepository itemTemplateCurrents { get; }
        IItemTemplateSteelTypeRepository itemTemplateSteelTypes { get; }
        IOrderRepository orders { get; }
        IOrderItemRepository orderItems { get; }
        IStatusRepository statuses { get; }
        ISteelTypeRepository steelTypes { get; }
        IUserRepository users { get; }


        Task saveAsync();
    }
}