using CosmeticShop.Shared.ResponseViewModels;
using CosmeticShop.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticShop.Business.Abstract
{
    public interface IShoppingCartItemService
    {
        Task<Response<NoContent>> ChangeQuantityAsync(int shoppingCartItemId, int quantity);
        Task<int> CountAsync(int shoppingCartId);
        Task<Response<NoContent>> DeleteFromShoppingCartAsync(int shoppingCartItemId);
        Task<Response<NoContent>> ClearShoppingCartAsync(int shoppingCartId);
        Task<ShoppingCartItemViewModel> GetShoppingCartItemAsync(int shoppingCartItemId);

    }
}
