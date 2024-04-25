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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(AddProductViewModel addProductViewModel)
        {
            var product = _mapper.Map<Product>(addProductViewModel);
            await _productRepository.AddAsync(product);
            product.ProductGenders = addProductViewModel.GenderIds.Select(x => new ProductGender
            {
                ProductId= product.Id,
                GenderId= x
            }).ToList();
            _productRepository.Update(product);

        }

        public async Task DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            _productRepository.Delete(product);
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            var products= await _productRepository.GetAllAsync();
            var productViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return productViewModel;
        }

        public async Task<List<ProductViewModel>> GetAllProductsWithCategories()
        {
            var products = await _productRepository.GetAllProductsWithCategories();
            var productViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return productViewModel;
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            var productViewModel =_mapper.Map<ProductViewModel>(product);
            return productViewModel;
        }

        public async Task<ProductViewModel> UpdateAsync(UpdateProductViewModel updateProductViewModel)
        {
            var product =  _mapper.Map<Product>(updateProductViewModel);
            product.ModifiedDate= DateTime.Now;
            //bu kısmı product güncelleme ekranımızı geliştirirken düzenleyeceğiz..
            _productRepository.Update(product);
            var productViewModel= _mapper.Map<ProductViewModel>(product);
            return productViewModel;

        }
    }
}