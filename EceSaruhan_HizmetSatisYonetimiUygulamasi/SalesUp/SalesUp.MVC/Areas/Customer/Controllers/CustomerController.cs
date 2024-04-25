using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SalesUp.Business.Abstract;
using SalesUp.Entity.Identity;
using SalesUp.Shared.ViewModels.Customer;
using SalesUp.Shared.ViewModels.STask;

namespace SalesUp.MVC.Areas.Customer.Controllers;

[Authorize(Roles = "Customer")]
[Area("Customer")]
public class CustomerController : Controller
{
    private readonly ICustomerService _customerManager;
    private readonly UserManager<User> _userManager;
    private readonly INotyfService _notyfService;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerService customerManager, UserManager<User> userManager, INotyfService notyfService, IMapper mapper)
    {
        _customerManager = customerManager;
        _userManager = userManager;
        _notyfService = notyfService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);
        var result = await _customerManager.GetCustomersByUserIdAsync(userId);
        return View(result.Data);
    }

 
    public async Task<IActionResult> Create()
    {

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddCustomerViewModel addCustomerViewModel)
    {
        var userId = _userManager.GetUserId(User);
        addCustomerViewModel.UserId = userId;

        var result = await _customerManager.CreateAsync(addCustomerViewModel);
        if (result.IsSucceeded)
        {
            _notyfService.Success("Müşteri bilgileri başarıyla kaydedildi.");
            return RedirectToAction("Index");
        }
        else
        {
            _notyfService.Error(result.Error);
            return View(addCustomerViewModel);
        }
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var customer = await _customerManager.GetByIdAsync(id);
        var userId = _userManager.GetUserId(User);
    
        CustomerViewModel customerViewModel= customer.Data;
        EditCustomerViewModel model = new EditCustomerViewModel
        {
            Id = customerViewModel.Id,
            FirstName =customerViewModel.FirstName,
            LastName = customerViewModel.LastName,
            CompanyName =customerViewModel.CompanyName,
            Title =customerViewModel.Title,
            Address =customerViewModel.Address,
            PhoneNumber = customerViewModel.PhoneNumber,
            Email =customerViewModel.PhoneNumber,
            CreatedDate =customerViewModel.CreatedDate,
            ModifiedDate = customerViewModel.ModifiedDate,
            UserId=customerViewModel.UserId
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditCustomerViewModel editCustomerViewModel)
    {
        var result = await _customerManager.UpdateAsync(editCustomerViewModel);
        if (result.IsSucceeded)
        {
            _notyfService.Success("Müşteri bilgileri başarıyla güncellenmiştir.");
            return RedirectToAction("Index");
        }
        else
        {
            _notyfService.Error(result.Error);
            return View(editCustomerViewModel);
        }
    }

    public async Task<IActionResult> HardDelete(int id)
    {
        await _customerManager.HardDeleteAsync(id);
        _notyfService.Success("Müşteri bilgileri başarıyla silinmiştir.");
        return RedirectToAction("Index");
    }
}