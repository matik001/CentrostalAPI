using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentrostalAPI.DB;
using CentrostalAPI.DB.IRepositories;
using CentrostalAPI.DB.Repositories;

namespace CentrostalAPI.DB {
    public class UnitOfWork : IUnitOfWork {
        public IItemsRepository items { get; }
        public IOrderRepository orders { get; }
        public IOrderItemRepository orderItems { get; }
        public IStatusRepository statuses { get; }
        public ISteelTypeRepository steelTypes { get; }
        public IUserRepository users { get; }
        public IRoleRepository roles { get; }
        public IUserRoleRepository userRoles { get; }


        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context) {
            _context = context;
            items = new ItemsRepository(context);
            orders = new OrderRepository(context);
            statuses = new StatusRepository(context);
            steelTypes = new SteelTypeRepository(context);
            users = new UserRepository(context);
            roles = new RoleRepository(context);
            userRoles = new UserRoleRepository(context);
        }
        public async Task saveAsync() {
            await _context.SaveChangesAsync();
        }
        public void Dispose() {
            _context.Dispose();
        }
    }
}
