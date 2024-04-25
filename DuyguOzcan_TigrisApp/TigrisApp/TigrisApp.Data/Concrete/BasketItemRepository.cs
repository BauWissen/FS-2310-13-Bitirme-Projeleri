using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigrisApp.Data.Abstract;
using TigrisApp.Entity.Concrete;

namespace TigrisApp.Data.Concrete
{
    public class BasketItemRepository : GenericRepository<BasketItem> , IBasketItemRepository
    {
        public BasketItemRepository(TigrisDbContext context) :base(context)
        {
            
        }
        private TigrisDbContext TigrisDbContext
        {
            get
            {
                return _dbContext as TigrisDbContext;
            }
        }
    }
}