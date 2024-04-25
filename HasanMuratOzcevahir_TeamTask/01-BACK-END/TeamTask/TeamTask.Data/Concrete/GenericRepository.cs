using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Data.Abstract;

namespace TeamTask.Data.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;
        DbSet<T> _table;
        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _table
                .AddAsync(entity);
            await _dbContext
                .SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync(
            Expression<Func<T, bool>> options = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _table;
            if (include != null)
            {
                query = include(query);
            }
            if (options != null)
            {
                query = query.Where(options);
            }
            var endQuery = query.ToListAsync();
            if (endQuery.Result.Count == 0)
            {
                return null;
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByConditionAsync(Expression<Func<T, bool>> options = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _table;
            if (include != null)
            {
                query = include(query);
            }
            if (options != null)
            {
                query = query.Where(options);
            }
            return await query.SingleOrDefaultAsync();
        }

        public async Task<int> GetCount(Expression<Func<T, bool>> options = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _table;
            if (include != null)
            {
                query = include(query);
            }
            if (options != null)
            {
                query = query.Where(options);
            }
            return await query.CountAsync();
        }

        public async Task<bool> HardDeleteAsync(T entity)
        {
            try
            {
                _table.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _table.Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }


    }
}
