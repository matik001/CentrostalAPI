using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentrostalAPI.DB;
using CentrostalAPI.DB.IRepositories;
using CentrostalAPI.DB.Repositories;

namespace CentrostalAPI.DB {
    public class UnitOfWork : IUnitOfWork {
        public IItemRepository items { get; }
        public IItemTemplateRepository itemTemplates { get; }
        public IItemTemplateCurrentRepository itemTemplateCurrents { get; }
        public IItemTemplateSteelTypeRepository itemTemplateSteelTypes { get; }
        public IOrderRepository orders { get; }
        public IOrderItemRepository orderItems { get; }
        public IStatusRepository statuses { get; }
        public ISteelTypeRepository steelTypes { get; }
        public IUserRepository users { get; }


        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context) {
            _context = context;
            items = new ItemRepository(context);
            itemTemplates = new ItemTemplateRepository(context);
            itemTemplateCurrents = new ItemTemplateCurrentRepository(context);
            itemTemplateSteelTypes = new ItemTemplateSteelTypeRepository(context);
            orders = new OrderRepository(context);
            statuses = new StatusRepository(context);
            steelTypes = new SteelTypeRepository(context);
            users = new UserRepository(context);
        }
        public async Task saveAsync() {
            await _context.SaveChangesAsync();
        }
        public void Dispose() {
            _context.Dispose();
        }
    }
}
