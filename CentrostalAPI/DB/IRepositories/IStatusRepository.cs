using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentrostalAPI.DB.IRepositories {
    public interface IStatusRepository : IGenericRepository<Status> {
    }
}
