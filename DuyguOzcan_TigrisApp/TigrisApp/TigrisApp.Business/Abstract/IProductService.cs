using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigrisApp.Shared.ViewModels;

namespace TigrisApp.Business.Abstract
{
    public interface IProductService
    {
        Task AddAsync(AddProductViewModel addProductViewModel);
        Task<ProductViewModel> UpdateAsync(UpdateProductViewModel updateProductViewModel);
        Task DeleteAsync(int id);
        Task<List<ProductViewModel>> GetAllAsync();
        Task<ProductViewModel> GetByIdAsync(int id);
        Task<List<ProductViewModel>> GetAllProductsWithCategories();
    }
}