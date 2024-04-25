using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigrisApp.Shared.ViewModels;

namespace TigrisApp.Business.Abstract
{
    public interface IColourService
    {
        Task AddAsync(AddColourViewModel addColourViewModel);
        Task<ColourViewModel> UpdateAsync(UpdateColourViewModel updateColourViewModel);
        Task DeleteAsync(int id);
        Task<ColourViewModel> GetByIdAsync(int id);
        Task<List<ColourViewModel>> GetAllAsync();
    }
}