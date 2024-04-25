using CosmeticShop.Data.Abstract;
using CosmeticShop.Data.Concrete.Contexts;
using CosmeticShop.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticShop.Data.Concrete.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CosmeticShopDbContext _context) : base(_context)
        {
        }

        private CosmeticShopDbContext CosmeticShopDbContext
        {
            get { return _dbContext as CosmeticShopDbContext; }
        }

        public async Task<List<Category>> GetTopCategories(int n)
        {
            List<Category> categories = await CosmeticShopDbContext
                .Categories
                .Where(c => c.IsActive && !c.IsDeleted)
                .Take(n)
                .ToListAsync();
            return categories;
        }
    }
}
