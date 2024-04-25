using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TeamTask.Data.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);

        Task<T> GetByConditionAsync(
           Expression<Func<T, bool>> options = null, Func<IQueryable<T>,
           IIncludableQueryable<T, object>> include = null);
        Task<List<T>> GetAllAsync(
            Expression<Func<T, bool>> options = null, Func<IQueryable<T>,
            IIncludableQueryable<T, object>> include = null);
        Task<bool> HardDeleteAsync(T entity);
        Task<int> GetCount(
            Expression<Func<T, bool>> options = null, Func<IQueryable<T>,
            IIncludableQueryable<T, object>> include = null
        );
    }
}
