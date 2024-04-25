using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesUp.Business.Abstract;
using SalesUp.Business.Mappings;
using SalesUp.Data.Abstract;
using SalesUp.Entity;
using SalesUp.Shared.ResponseViewModels;
using SalesUp.Shared.ViewModels.Product;
using SalesUp.Shared.ViewModels.STask;

namespace SalesUp.Business.Concrete;

public class ProductManager :IProductService
{
  private readonly IMapper _mapper;
  private readonly IProductRepository _repository;

  public ProductManager(IMapper mapper, IProductRepository repository)
  {
    _mapper = mapper;
    _repository = repository;
  }

    public async Task<Response<ProductViewModel>> CreateAsync(AddProductViewModel addProductViewModel)
    {
        var product = _mapper.Map<Product>(addProductViewModel);
        product.CreatedDate = DateTime.Now;
        product.ModifiedDate = DateTime.Now;
        product.IsActive = true;

        var createdProduct = await _repository.CreateAsync(product);
        if (createdProduct == null)
        {
            return Response<ProductViewModel>.Fail("Bir hata oluştu");
        }
        await _repository.UpdateAsync(createdProduct);
        var productViewModel = _mapper.Map<ProductViewModel>(createdProduct);
        return Response<ProductViewModel>.Success(productViewModel);
    }

  

    public async Task<Response<ProductViewModel>> GetByIdAsync(int id)
    {
        var product = await _repository.GetByIdAsync(p => p.Id == id);
        if (product == null)
        {
            return Response<ProductViewModel>.Fail("İlgili ürün bulunamadı.");
        }

        var productViewModel = _mapper.Map<ProductViewModel>(product);
        return Response<ProductViewModel>.Success(productViewModel);
    }

    public async Task<Response<List<ProductViewModel>>> GetProductsByUserIdAsync(string userId)
    {
        var productList = await _repository.GetAllAsync(x => x.UserId == userId,
           source => source
               .Include(x => x.User));
        if (productList.Count == 0)
        {
            return Response<List<ProductViewModel>>.Fail("Bu kullanıcıya ait ürün bulunamadı.");
        }

        var productListViewModel = _mapper.Map<List<ProductViewModel>>(productList);
        return Response<List<ProductViewModel>>.Success(productListViewModel);
    }

    public async Task<Response<NoContent>> HardDeleteAsync(int id)
    {
        var product = await _repository.GetByIdAsync(p => p.Id == id);
        if (product == null)
        {
            return Response<NoContent>.Fail("İlgili ürün bulunamadı.");
        }

        await _repository.HardDeleteAsync(product);
        return Response<NoContent>.Success();
    }

    public async Task<Response<ProductViewModel>> UpdateAsync(EditProductViewModel editProductViewModel)
    {
        var editedProduct = _mapper.Map<Product>(editProductViewModel);
        if (editedProduct == null)
        {
            return Response<ProductViewModel>.Fail("İlgili ürün bulunamadı.");
        }
        editedProduct.ModifiedDate = DateTime.Now;
        await _repository.UpdateAsync(editedProduct);
        var productViewModel = _mapper.Map<ProductViewModel>(editedProduct);
        return Response<ProductViewModel>.Success(productViewModel);
    }

    public async Task<Response<NoContent>> UpdateIsActiveAsync(int id)
    {
        var product = await _repository.GetByIdAsync(p => p.Id == id);
        if (product == null)
        {
            return Response<NoContent>.Fail("İlgili ürün bulunamadı.");
        }
        product.IsActive = !product.IsActive;
        product.ModifiedDate = DateTime.Now;
        await _repository.UpdateAsync(product);
        return Response<NoContent>.Success();
    }
}