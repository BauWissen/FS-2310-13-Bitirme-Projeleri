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
    public class OrderRepository:GenericRepository<Order>,IOrderRepository
    {
        public OrderRepository(CosmeticShopDbContext _context):base(_context) 
        {

        }
        CosmeticShopDbContext CosmeticShopDbContext { get { return _dbContext as CosmeticShopDbContext; } }

        public async Task<List<Order>> GetAllOrdersByProductIdAsync(int productId)
        {
            var result = await CosmeticShopDbContext
               .Orders
               .Include(o => o.OrderDetails)
               .ThenInclude(od => od.Product)
               .Where(o => o.OrderDetails.Any(x => x.ProductId == productId))
               .OrderByDescending(x => x.Id)
               .ToListAsync();
            return result;
        }
    }
}
