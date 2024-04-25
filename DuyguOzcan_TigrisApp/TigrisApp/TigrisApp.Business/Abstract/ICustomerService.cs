using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigrisApp.Shared.ViewModels;

namespace TigrisApp.Business.Abstract
{
    public interface ICustomerService
    {
        Task AddAsync(AddCustomerViewModel addCustomerViewModel);
        Task<CustomerViewModel> UpdateAsync(UpdateCustomerViewModel updateCustomerViewModel);
        Task DeleteAsync(int id);
        Task<CustomerViewModel> GetByIdAsync(int id);
        Task<List<CustomerViewModel>> GetAllAsync();
    }
}