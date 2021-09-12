using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB.IRepositories;
using CentrostalAPI.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace CentrostalAPI.DB.Repositories {
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IHavingId {

        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context) {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public virtual async Task<IList<T>> all(Expression<Func<T, bool>> expression = null,
                                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                IEnumerable<string> includes = null, int? limit = null, bool attach = false) {
            IQueryable<T> query = _dbSet;
            if(expression != null) {
                query = query.Where(expression);
            }
            if(includes != null) {
                foreach(var includeProperty in includes) {
                    query = query.Include(includeProperty);
                }
            }
            if(orderBy != null) {
                query = orderBy(query);
            }
            if(limit != null) {
                query = query.Take(limit.Value);
            }

            if(!attach) {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();
        }

        public virtual async Task<T> one(Expression<Func<T, bool>> expression, IEnumerable<string> includes = null, bool attach = false) {
            IQueryable<T> query = _dbSet;
            if(includes != null) {
                foreach(var includeProperty in includes) {
                    query = query.Include(includeProperty);
                }
            }
            if(!attach) {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(expression);
        }

        public virtual async Task<T> getById(int id, IEnumerable<string> includes = null, bool attach = false) {
            return await one(a => a.id == id, includes, attach);
        }

        public async Task explicitLoad(T model, IEnumerable<string> includedCollections = null,
            IEnumerable<string> includedReferences = null) {
            if(model != null) {
                if(includedReferences != null)
                    foreach(var path in includedReferences) {
                        await _context.Entry((object)model).Reference(path).LoadAsync();
                    }

                if(includedCollections != null)
                    foreach(var path in includedCollections) {
                        await _context.Entry((object)model).Collection(path).LoadAsync();
                    }
            }
        }

        public virtual async Task add(T entity) {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task addRange(IEnumerable<T> entity) {
            await _dbSet.AddRangeAsync(entity);
        }

        public virtual async Task delete(int id) {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }
        public virtual Task delete(T entity) {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }


        public virtual Task deleteRange(IEnumerable<T> entities) {
            _dbSet.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public virtual Task attach(T entity) {
            _dbSet.Attach(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
