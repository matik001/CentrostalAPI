using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB.Models;

namespace CentrostalAPI.DB.IRepositories {
    public interface IGenericRepository<T> where T : class, IHavingId {
        Task<IList<T>> all(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            IEnumerable<string> includes = null, int? limit = null, bool attach = false);

        Task<T> one(Expression<Func<T, bool>> expression, IEnumerable<string> includes = null, bool attach = false);
        Task<T> getById(int id, IEnumerable<string> includes = null, bool attach = false);

        Task explicitLoad(T model, IEnumerable<string> includedCollections = null,
            IEnumerable<string> includedReferences = null);
        Task add(T entity);
        Task addRange(IEnumerable<T> entity);
        Task delete(int id);
        Task delete(T entity);
        Task deleteRange(IEnumerable<T> entities);
        Task attach(T entity);
    }
}
