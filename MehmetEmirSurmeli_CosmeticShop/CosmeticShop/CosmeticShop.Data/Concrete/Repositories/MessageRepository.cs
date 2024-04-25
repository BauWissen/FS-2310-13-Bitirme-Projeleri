using CosmeticShop.Data.Abstract;
using CosmeticShop.Data.Concrete.Contexts;
using CosmeticShop.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticShop.Data.Concrete.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(CosmeticShopDbContext _context) : base(_context)
        {

        }
        CosmeticShopDbContext CosmeticShopDbContext
        {
            get { return _dbContext as CosmeticShopDbContext; }
        }
    }
}
