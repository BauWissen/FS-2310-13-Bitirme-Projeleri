using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TigrisApp.Business.Abstract;
using TigrisApp.Data.Abstract;
using TigrisApp.Entity.Concrete;
using TigrisApp.Shared.ViewModels;

namespace TigrisApp.Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(AddCustomerViewModel addCustomerViewModel)
        {
            var customer = _mapper.Map<Customer>(addCustomerViewModel);
            await _customerRepository.AddAsync(customer);
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            _customerRepository.Delete(customer);
        }

        public async Task<List<CustomerViewModel>> GetAllAsync()
        {
            var customers= await _customerRepository.GetAllAsync();
            var customerViewModels = _mapper.Map<List<CustomerViewModel>>(customers);
            return customerViewModels;
        }

        public async Task<CustomerViewModel> GetByIdAsync(int id)
        {
            var customer= await _customerRepository.GetByIdAsync(id);
            var customerViewModel = _mapper.Map<CustomerViewModel>(customer);
            return customerViewModel;
        }

        public async Task<CustomerViewModel> UpdateAsync(UpdateCustomerViewModel updateCustomerViewModel)
        {
            var customer= _mapper.Map<Customer>(updateCustomerViewModel);
            _customerRepository.Update(customer);
            var customerViewModel= _mapper.Map<CustomerViewModel>(customer);
            return customerViewModel;
        }
    }
}