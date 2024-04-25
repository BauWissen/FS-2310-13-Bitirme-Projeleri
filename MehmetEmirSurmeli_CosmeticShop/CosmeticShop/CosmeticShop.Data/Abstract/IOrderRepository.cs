using CosmeticShop.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticShop.Data.Abstract
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        Task<List<Order>> GetAllOrdersByProductIdAsync(int productId);

    }
}
