using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigrisApp.Shared.ViewModels;

namespace TigrisApp.Business.Abstract
{
    public interface ICategoryService
    {
        Task AddAsync(AddCategoryViewModel addCategoryViewModel);
        Task<CategoryViewModel> UpdateAsync(UpdateCategoryViewModel updateCategoryViewModel);
        Task DeleteAsync(int id);
        Task<List<CategoryViewModel>> GetAllAsync();
        Task<CategoryViewModel> GetByIdAsync(int id);

    }
}