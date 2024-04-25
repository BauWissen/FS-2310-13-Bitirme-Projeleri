using SalesUp.Shared.ResponseViewModels;
using SalesUp.Shared.ViewModels.Customer;
using SalesUp.Shared.ViewModels.Product;

namespace SalesUp.Business.Abstract;

public interface ICustomerService
{
    Task<Response<CustomerViewModel>> CreateAsync(AddCustomerViewModel addCustomerViewModel);
    Task<Response<CustomerViewModel>> UpdateAsync(EditCustomerViewModel editCustomerViewModel);
    Task<Response<NoContent>> HardDeleteAsync(int id);
    Task<Response<CustomerViewModel>> GetByIdAsync(int id);
    Task<Response<List<CustomerViewModel>>> GetCustomersByUserIdAsync(string userId);

}