using SalesUp.Shared.ResponseViewModels;
using SalesUp.Shared.ViewModels.Product;
using SalesUp.Shared.ViewModels.STask;

namespace SalesUp.Business.Abstract;

public interface IProductService
{
    Task<Response<ProductViewModel>> CreateAsync(AddProductViewModel addProductViewModel);
    Task<Response<ProductViewModel>> UpdateAsync(EditProductViewModel editProductViewModel);
    Task<Response<NoContent>> HardDeleteAsync(int id);
    Task<Response<ProductViewModel>> GetByIdAsync(int id);
    Task<Response<List<ProductViewModel>>> GetProductsByUserIdAsync(string userId);
    Task<Response<NoContent>> UpdateIsActiveAsync(int id);

}