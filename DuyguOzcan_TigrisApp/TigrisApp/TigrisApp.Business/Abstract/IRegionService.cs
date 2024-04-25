using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigrisApp.Shared.ViewModels;

namespace TigrisApp.Business.Abstract
{
    public interface IRegionService
    {
        Task AddAsync(AddRegionViewModel addRegionViewModel);
        Task<RegionViewModel> UpdateAsync(UpdateRegionViewModel updateRegionViewModel);
        Task DeleteAsync(int id );
        Task<RegionViewModel> GetByIdAsync(int id);
        Task<List<RegionViewModel>> GetAllAsync();
    }
}