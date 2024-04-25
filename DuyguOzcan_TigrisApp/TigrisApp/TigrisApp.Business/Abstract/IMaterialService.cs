using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigrisApp.Shared.ViewModels;

namespace TigrisApp.Business.Abstract
{
    public interface IMaterialService
    {
        Task AddAsync(AddMaterialViewModel addMaterialViewModel);
        Task<MaterialViewModel> UpdateAsync(UpdateMaterialViewModel updateMaterialViewModel);
        Task DeleteAsync(int id);
        Task<List<MaterialViewModel>> GetAllAsync();
        Task<MaterialViewModel> GetByIdAsync(int id);
        
    }
}