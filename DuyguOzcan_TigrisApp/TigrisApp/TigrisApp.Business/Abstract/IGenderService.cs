using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigrisApp.Entity.Concrete;
using TigrisApp.Shared.ViewModels;

namespace TigrisApp.Business.Abstract
{
    public interface IGenderService
    {
        Task AddAsync(AddGenderViewModel addGenderViewModel);
        Task<GenderViewModel> UpdateAsync(UpdateGenderViewModel updateGenderViewModel);
        Task DeleteAsync(int id);
        Task<GenderViewModel> GetByIdAsync(int id);
        Task<List<GenderViewModel>> GetAllAsync();
    }
}