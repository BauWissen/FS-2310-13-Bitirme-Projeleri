using SalesUp.Shared.ResponseViewModels;
using SalesUp.Shared.ViewModels.Subscription;

namespace SalesUp.Business.Abstract;

public interface ISubscriptionService
{
    Task<Response<SubscriptionViewModel>> CreateAsync(AddSubscriptionViewModel addSubscriptionViewModel);
    Task<Response<SubscriptionViewModel>> UpdateAsync(EditSubscriptionViewModel editSubscriptionViewModel);
    Task<Response<NoContent>> HardDeleteAsync(int id);
    Task<Response<SubscriptionViewModel>> GetByIdAsync(int id);
    Task<Response<List<SubscriptionViewModel>>> GetAllAsync();
    
}