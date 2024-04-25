using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SalesUp.Business.Abstract;
using SalesUp.Entity.Identity;
using SalesUp.Shared.ViewModels.Product;
using SalesUp.Shared.ViewModels.STask;

namespace SalesUp.MVC.Areas.Customer.Controllers;

[Authorize(Roles = "Customer")]
[Area("Customer")]
public class ProductController : Controller
{
    private readonly IProductService _productManager;
    private readonly UserManager<User> _userManager;
    private readonly INotyfService _notyfService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productManager, UserManager<User> userManager, INotyfService notyfService, IMapper mapper)
    {
        _productManager = productManager;
        _userManager = userManager;
        _notyfService = notyfService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);
        var products = await _productManager.GetProductsByUserIdAsync(userId);
        return View(products.Data);
    }

    public async Task<IActionResult> UpdateIsActive(int id)
    {
        var result = await _productManager.UpdateIsActiveAsync(id);
        var product = await _productManager.GetByIdAsync(id);
        return Json(product.Data.IsActive);
    }
    public async Task<IActionResult> Create()
    {

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddProductViewModel addProductViewModel)
    {
        var userId = _userManager.GetUserId(User);
        addProductViewModel.UserId = userId;

        var result = await _productManager.CreateAsync(addProductViewModel);
        if (result.IsSucceeded)
        {
            _notyfService.Success("Ürün başarıyla kaydedildi.");
            return RedirectToAction("Index");
        }
        else
        {
            _notyfService.Error(result.Error);
            return View(addProductViewModel);
        }
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _productManager.GetByIdAsync(id);
        var userId = _userManager.GetUserId(User);
   
        ProductViewModel productViewModel = product.Data;
        EditProductViewModel model = new EditProductViewModel
        {
            Id = productViewModel.Id,
            Name = productViewModel.Name,
            Properties =productViewModel.Properties,
            Unit = productViewModel.Unit,
            UnitPrice = productViewModel.UnitPrice,
            Quantity = productViewModel.Quantity,
            IsActive = productViewModel.IsActive,
            CreatedDate =productViewModel.CreatedDate,
            ModifiedDate = productViewModel.ModifiedDate,
            UserId = productViewModel.UserId
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditProductViewModel editProductViewModel)
    {
        var result = await _productManager.UpdateAsync(editProductViewModel);
        if (result.IsSucceeded)
        {
            _notyfService.Success("Ürün başarıyla güncellenmiştir.");
            return RedirectToAction("Index");
        }
        else
        {
            _notyfService.Error(result.Error);
            return View(editProductViewModel);
        }
    }

    public async Task<IActionResult> HardDelete(int id)
    {
        await _productManager.HardDeleteAsync(id);
        _notyfService.Success("Ürün başarıyla silinmiştir.");
        return RedirectToAction("Index");
    }
}