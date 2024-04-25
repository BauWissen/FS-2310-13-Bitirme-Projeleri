using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesUp.Business.Abstract;
using SalesUp.Business.Mappings;
using SalesUp.Data.Abstract;
using SalesUp.Entity;
using SalesUp.Shared.ResponseViewModels;
using SalesUp.Shared.ViewModels.Customer;
using SalesUp.Shared.ViewModels.STask;

namespace SalesUp.Business.Concrete;

public class CustomerManager : ICustomerService
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _repository;


    public CustomerManager(IMapper mapper, ICustomerRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<CustomerViewModel>> CreateAsync(AddCustomerViewModel addCustomerViewModel)
    {
        var customer = _mapper.Map<Customer>(addCustomerViewModel);
        customer.CreatedDate = DateTime.Now;
        customer.ModifiedDate = DateTime.Now;
    

        var createdCustomer = await _repository.CreateAsync(customer);
        if (createdCustomer == null)
        {
            return Response<CustomerViewModel>.Fail("Bir hata oluştu");
        }
        await _repository.UpdateAsync(createdCustomer);
        var customerViewModel = _mapper.Map<CustomerViewModel>(createdCustomer);
        return Response<CustomerViewModel>.Success(customerViewModel);
    }

   

    public async Task<Response<CustomerViewModel>> GetByIdAsync(int id)
    {
        var customer = await _repository.GetByIdAsync(c => c.Id == id);
        if (customer == null)
        {
            return Response<CustomerViewModel>.Fail("İlgili müşteri bulunamadı.");
        }

        var customerViewModel = _mapper.Map<CustomerViewModel>(customer);
        return Response<CustomerViewModel>.Success(customerViewModel);
    }

    public async Task<Response<List<CustomerViewModel>>> GetCustomersByUserIdAsync(string userId)
    {
        var customerList = await _repository.GetAllAsync(x => x.UserId == userId,
           source => source
               .Include(x => x.User));
        if (customerList.Count == 0)
        {
            return Response<List<CustomerViewModel>>.Fail("Bu kullanıcıya ait müşteri bulunamadı.");
        }

        var customerListViewModel = _mapper.Map<List<CustomerViewModel>>(customerList);
        return Response<List<CustomerViewModel>>.Success(customerListViewModel);
    }

    public async Task<Response<NoContent>> HardDeleteAsync(int id)
    {
        var customer= await _repository.GetByIdAsync(c => c.Id == id);
        if (customer == null)
        {
            return Response<NoContent>.Fail("İlgili müşteri bulunamadı.");
        }

        await _repository.HardDeleteAsync(customer);
        return Response<NoContent>.Success();
    }

    public async Task<Response<CustomerViewModel>> UpdateAsync(EditCustomerViewModel editCustomerViewModel)
    {
        var editedCustomer = _mapper.Map<Customer>(editCustomerViewModel);
        if (editedCustomer == null)
        {
            return Response<CustomerViewModel>.Fail("İlgili müşteri bulunamadı.");
        }
        editedCustomer.ModifiedDate = DateTime.Now;
        await _repository.UpdateAsync(editedCustomer);
        var customerViewModel = _mapper.Map<CustomerViewModel>(editedCustomer);
        return Response<CustomerViewModel>.Success(customerViewModel);
    }
}