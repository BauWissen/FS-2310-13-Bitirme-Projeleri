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
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(AddSupplierViewModel addSupplierViewModel)
        {
            var supplier = _mapper.Map<Supplier>(addSupplierViewModel);
            await _supplierRepository.AddAsync(supplier);
        }

        public async Task DeleteAsync(int id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);
            _supplierRepository.Delete(supplier);
        }

        public async Task<List<SupplierViewModel>> GetAllAsync()
        {
            var suppliers= await _supplierRepository.GetAllAsync();
            var supplierViewModels = _mapper.Map<List<SupplierViewModel>>(suppliers);
            return supplierViewModels;
        }

        public async Task<SupplierViewModel> GetByIdAsync(int id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);
            var supplierViewModel = _mapper.Map<SupplierViewModel>(supplier);
            return supplierViewModel;
        }

        public async Task<SupplierViewModel> UpdateAsync(UpdateSupplierViewModel updateSupplierViewModel)
        {
            var supplier =  _mapper.Map<Supplier>(updateSupplierViewModel);
            _supplierRepository.Update(supplier);
            var supplierViewModel= _mapper.Map<SupplierViewModel>(supplier);
            return supplierViewModel;
        }
    }
}