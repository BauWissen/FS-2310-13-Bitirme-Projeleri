using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesUp.Business.Abstract;
using SalesUp.Business.Mappings;
using SalesUp.Data.Abstract;
using SalesUp.Entity;
using SalesUp.Shared.ResponseViewModels;
using SalesUp.Shared.ViewModels.Product;
using SalesUp.Shared.ViewModels.Sale;
using SalesUp.Shared.ViewModels.STask;

namespace SalesUp.Business.Concrete;

public class SaleManager : ISaleService
{
   private readonly IMapper _mapper;
   private readonly ISaleRepository _repository;


   public SaleManager(IMapper mapper, ISaleRepository repository)
   {
      _mapper = mapper;
      _repository = repository;
   }

    public async Task<Response<SaleViewModel>> CreateAsync(AddSaleViewModel addSaleViewModel)
    {
        var sale = _mapper.Map<Sale>(addSaleViewModel);
        sale.CreatedDate = DateTime.Now;
        sale.IsCompleted = false;

        var createdSale = await _repository.CreateAsync(sale);
        if (createdSale == null)
        {
            return Response<SaleViewModel>.Fail("Bir hata oluştu");
        }
        await _repository.UpdateAsync(createdSale);
        var saleViewModel = _mapper.Map<SaleViewModel>(createdSale);
        return Response<SaleViewModel>.Success(saleViewModel);
    }

    public async Task<Response<NoContent>> DeleteAllAsync(string userId)
    {
        await _repository.DeleteAllAsync(userId);
        return Response<NoContent>.Success();
    }

    public async Task<Response<List<SaleViewModel>>> GetAllCompletedAsync(bool isCompleted = true)
    {
        var saleList = await _repository.GetAllAsync(s => s.IsCompleted == isCompleted);
        if(saleList == null)
        {
            return Response<List<SaleViewModel>>.Fail("Tamamlanmış satış bulunamadı");
        }
        var saleViewModel = _mapper.Map<List<SaleViewModel>>(saleList);
        return Response<List<SaleViewModel>>.Success(saleViewModel);
    }

    public async Task<Response<SaleViewModel>> GetByIdAsync(int id)
    {
        var sale = await _repository.GetByIdAsync(s => s.Id == id);
        if (sale == null)
        {
            return Response<SaleViewModel>.Fail("İlgili görev bulunamadı.");
        }

        var saleViewModel = _mapper.Map<SaleViewModel>(sale);
        return Response<SaleViewModel>.Success(saleViewModel);
    }

    public async Task<Response<List<SaleViewModel>>> GetSalesByUserIdAsync(string userId)
    {
        var saleList = await _repository.GetAllAsync(x => x.UserId == userId,
             source => source
                 .Include(x => x.User));
        if (saleList.Count == 0)
        {
            return Response<List<SaleViewModel>>.Fail("Bu kullanıcıya ait görev bulunamadı.");
        }

        var saleListViewModel = _mapper.Map<List<SaleViewModel>>(saleList);
        return Response<List<SaleViewModel>>.Success(saleListViewModel);
    }

    public async Task<Response<NoContent>> HardDeleteAsync(int id)
    {
        var sale = await _repository.GetByIdAsync(s => s.Id == id);
        if (sale == null)
        {
            return Response<NoContent>.Fail("İlgili görev bulunamadı.");
        }

        await _repository.HardDeleteAsync(sale);
        return Response<NoContent>.Success();
    }

    public async Task<Response<SaleViewModel>> UpdateAsync(EditSaleViewModel editSaleViewModel)
    {
        var editedSale = _mapper.Map<Sale>(editSaleViewModel);
        if (editedSale == null)
        {
            return Response<SaleViewModel>.Fail("İlgili görev bulunamadı");
        }
        
        await _repository.UpdateAsync(editedSale);
        var saleViewModel = _mapper.Map<SaleViewModel>(editedSale);
        return Response<SaleViewModel>.Success(saleViewModel);
    }

    public async Task<Response<NoContent>> UpdateIsCompletedAsync(int id)
    {
        var sale = await _repository.GetByIdAsync(s => s.Id == id);
        if (sale == null)
        {
            return Response<NoContent>.Fail("İlgili görev bulunamadı.");
        }
        sale.IsCompleted = !sale.IsCompleted;
        sale.CompletedDate = DateTime.Now;
        await _repository.UpdateAsync(sale);
        return Response<NoContent>.Success();
    }
}