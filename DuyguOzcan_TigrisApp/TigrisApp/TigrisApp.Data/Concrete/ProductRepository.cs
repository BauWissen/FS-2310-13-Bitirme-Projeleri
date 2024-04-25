using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TigrisApp.Data.Abstract;
using TigrisApp.Entity.Concrete;

namespace TigrisApp.Data.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(TigrisDbContext context) : base(context)
        {
            
        }
        private TigrisDbContext TigrisDbContext
        {
            get
            {
                return _dbContext as TigrisDbContext;
            }
        }

        public async Task<List<Product>> GetAllProductsWithCategories()
        {
            var products = await  TigrisDbContext
                .Products
                .Include(x => x.Category)
                .ToListAsync();
                return products;
        }
    }
}