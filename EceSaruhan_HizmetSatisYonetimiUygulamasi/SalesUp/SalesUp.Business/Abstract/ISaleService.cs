using SalesUp.Shared.ResponseViewModels;
using SalesUp.Shared.ViewModels.STask;
using SalesUp.Shared.ViewModels.Sale;
namespace SalesUp.Business.Abstract;

public interface ISaleService
{
    Task<Response<SaleViewModel>> CreateAsync(AddSaleViewModel addSaleViewModel);
    Task<Response<SaleViewModel>> UpdateAsync(EditSaleViewModel editSaleViewModel);
    Task<Response<NoContent>> HardDeleteAsync(int id);
    Task<Response<SaleViewModel>> GetByIdAsync(int id);
    Task<Response<List<SaleViewModel>>> GetSalesByUserIdAsync(string userId);
    Task<Response<NoContent>> DeleteAllAsync(string userId);
    Task<Response<NoContent>> UpdateIsCompletedAsync(int id);
    Task<Response<List<SaleViewModel>>> GetAllCompletedAsync(bool isCompleted = true);
}