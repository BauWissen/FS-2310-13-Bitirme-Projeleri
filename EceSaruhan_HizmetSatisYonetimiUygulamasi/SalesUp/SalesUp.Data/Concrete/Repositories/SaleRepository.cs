using Microsoft.EntityFrameworkCore;
using SalesUp.Data.Abstract;
using SalesUp.Data.Concrete.Contexts;
using SalesUp.Entity;

namespace SalesUp.Data.Concrete.Repositories;

public class SaleRepository : GenericRepository<Sale>, ISaleRepository
{
    public SaleRepository(SalesUpDbContext context) : base(context)
    {
    }

    private SalesUpDbContext? SalesUpDbContext => DbContext as SalesUpDbContext;

    public async Task DeleteAllAsync(string userId)
    {
        var deletedTaskList = await SalesUpDbContext
          .Tasks
          .Include(x => x.User)
          .Where(x => x.UserId == userId)
          .ToListAsync();

        SalesUpDbContext.Tasks.RemoveRange(deletedTaskList);
        await SalesUpDbContext.SaveChangesAsync();
    }
}