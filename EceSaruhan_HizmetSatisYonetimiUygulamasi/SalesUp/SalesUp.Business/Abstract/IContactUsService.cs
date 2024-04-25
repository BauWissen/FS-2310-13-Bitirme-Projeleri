using System;
using SalesUp.Shared.ResponseViewModels;
using SalesUp.Shared.ViewModels;
using SalesUp.Shared.ViewModels.STask;

namespace SalesUp.Business.Abstract
{
	public interface IContactUsService
	{
        Task<Response<ContactUsViewModel>> CreateAsync(ContactUsViewModel contactUsViewModel);
        Task<Response<List<ContactUsViewModel>>> GetAllAsync();
        Task<Response<NoContent>> HardDeleteAsync(int id);
        Task<Response<ContactUsViewModel>> GetByIdAsync(int id);
        Task<Response<NoContent>> UpdateIsCompletedAsync(int id);
    }
}

