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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(CosmeticShopDbContext _context) : base(_context)
        {

        }
        private CosmeticShopDbContext CosmeticShopDbContext
        {
            get { return _dbContext as CosmeticShopDbContext; }
        }

        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            List<Product> products = await CosmeticShopDbContext
                .Products
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .Where(p => p.ProductCategories.Any(pc => pc.CategoryId == categoryId))
                .ToListAsync();
            return products;
        }

        public async Task ClearProductCategory(int productId, List<int> categoryIds)
        {
            List<ProductCategory> productCategories = await CosmeticShopDbContext
                .ProductCategories
                .Where(pc => pc.ProductId == productId)
                .ToListAsync();
            CosmeticShopDbContext.ProductCategories.RemoveRange(productCategories);
            await CosmeticShopDbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProductsByCategoryUrlAsync(string categoryUrl)
        {
            List<Product> products = await CosmeticShopDbContext
                .Products
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .Where(p => p.ProductCategories.Any(pc => pc.Category.Url == categoryUrl))
                .ToListAsync();
            return products;
        }
    }
}
