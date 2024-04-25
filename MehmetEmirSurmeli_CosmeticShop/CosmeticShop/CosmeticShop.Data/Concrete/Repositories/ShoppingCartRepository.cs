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
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(CosmeticShopDbContext _context) : base(_context)
        {

        }
        private CosmeticShopDbContext CosmeticShopDbContext
        {
            get { return _dbContext as CosmeticShopDbContext; }
        }
        public async Task ClearShoppingCartAsync(int shoppingCartId)
        {
            var deletedShoppingCartItems = await CosmeticShopDbContext
                .ShoppingCartItems
                .Where(x => x.ShoppingCartId == shoppingCartId)
                .ToListAsync();
            CosmeticShopDbContext.ShoppingCartItems.RemoveRange(deletedShoppingCartItems);
            await CosmeticShopDbContext.SaveChangesAsync();
        }

        public async Task DeleteFromShoppingCartAsync(int shoppingCartId, int productId)
        {
            var deletedShoppingCartItem = await CosmeticShopDbContext
                .ShoppingCartItems
                .Where(x => x.ShoppingCartId == shoppingCartId && x.ProductId == productId)
                .FirstOrDefaultAsync();
            CosmeticShopDbContext.ShoppingCartItems.Remove(deletedShoppingCartItem);
            await CosmeticShopDbContext.SaveChangesAsync();
        }

        public async Task<ShoppingCart> GetShoppingCartByUserIdAsync(string userId)
        {
            var shoppingCart = await CosmeticShopDbContext
                .ShoppingCarts
                .Where(sc => sc.UserId == userId)
                .Include(sc => sc.ShoppingCartItems)
                .ThenInclude(sci => sci.Product)
                .FirstOrDefaultAsync();
            return shoppingCart;
        }
    }
}
