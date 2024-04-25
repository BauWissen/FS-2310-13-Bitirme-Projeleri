using CosmeticShop.Entity.Concrete;
using CosmeticShop.Shared.ComplexTypes;
using CosmeticShop.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticShop.Business.Abstract
{
    public interface IOrderService
    {
        Task CreateAsync(Order order);
        Task<List<AdminOrderViewModel>> GetOrdersAsync();
        Task<List<AdminOrderViewModel>> GetOrdersAsync(string userId);
        Task<List<AdminOrderViewModel>> GetOrdersAsync(int productId);
        Task<AdminOrderViewModel> GetOrderAsync(int orderId);
        Task CancelOrder(int orderId);
        Task<OrderState> ChangeStatus(int id, OrderState orderState);
    }
}
