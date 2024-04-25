using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigrisApp.Shared.ViewModels;

namespace TigrisApp.Business.Abstract
{
    public interface ISupplierService
    {
        Task AddAsync(AddSupplierViewModel addSupplierViewModel);
        Task<SupplierViewModel> UpdateAsync(UpdateSupplierViewModel updateSupplierViewModel);
        Task DeleteAsync(int id);
        Task<SupplierViewModel> GetByIdAsync(int id);
        Task<List<SupplierViewModel>> GetAllAsync();
    }
}