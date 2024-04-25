using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SalesUp.Data.Abstract;

namespace SalesUp.Data.Concrete.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly DbContext DbContext;

    public GenericRepository(DbContext dbContext)
    {
        DbContext = dbContext;
    }
    
    public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> options = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
        IQueryable<TEntity> query = DbContext.Set<TEntity>();
        {
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
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> options = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
        IQueryable<TEntity> query = DbContext.Set<TEntity>();
        {
            if (include != null)
            {
                query = include(query);
            }
            if (options != null)
            {
                query = query.Where(options);
            }
            return await query.ToListAsync();
        }
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await DbContext
            .Set<TEntity>()
            .AddAsync(entity);
        await DbContext
            .SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        DbContext
            .Set<TEntity>()
            .Update(entity);
        await DbContext.SaveChangesAsync();
    }

    public async Task HardDeleteAsync(TEntity entity)
    {
        DbContext
            .Set<TEntity>()
            .Remove(entity);
        await DbContext.SaveChangesAsync();
    }

    public async Task<int> GetCount(Expression<Func<TEntity, bool>> options = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
        IQueryable<TEntity> query = DbContext.Set<TEntity>();
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
}