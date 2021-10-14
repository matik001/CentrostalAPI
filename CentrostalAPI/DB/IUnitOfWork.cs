using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB.IRepositories;

namespace CentrostalAPI.DB {
    public interface IUnitOfWork : IDisposable {
        IItemsRepository items { get; }
        IOrderRepository orders { get; }
        IOrderItemRepository orderItems { get; }
        IStatusRepository statuses { get; }
        ISteelTypeRepository steelTypes { get; }
        IUserRepository users { get; }
        IRoleRepository roles { get; }
        IUserRoleRepository userRoles { get; }

        Task saveAsync();
    }
}
