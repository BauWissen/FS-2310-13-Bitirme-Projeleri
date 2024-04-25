using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesUp.Business.Abstract;
using SalesUp.Shared.ResponseViewModels;
using SalesUp.Shared.ViewModels.Subscription;

namespace SalesUp.MVC.Areas.Admin.Controllers;

[Authorize(Roles = "SuperAdmin, Admin")]
[Area("Admin")]
public class SubscriptionController : Controller
{
    private readonly ISubscriptionService _subscriptionManager;

    private readonly INotyfService _notyfService;
    // GET
    public SubscriptionController(ISubscriptionService subscriptionManager, INotyfService notyfService)
    {
        _subscriptionManager = subscriptionManager;
        _notyfService = notyfService;
    }

    public async Task<IActionResult> Index()
    {
        Response<List<SubscriptionViewModel>> result = await _subscriptionManager.GetAllAsync();
        return View(result.Data);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddSubscriptionViewModel addSubscriptionViewModel)
    {
        var subscriptionViewModel = await _subscriptionManager.CreateAsync(addSubscriptionViewModel);
        if (subscriptionViewModel.IsSucceeded)
        {
            _notyfService.Success("Abonelik başarıyla kaydedilmiştir.");
            return RedirectToAction("Index");
        }
        else
        {
            _notyfService.Error(subscriptionViewModel.Error);
            return View(addSubscriptionViewModel);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var subscription = await _subscriptionManager.GetByIdAsync(id);
        SubscriptionViewModel subscriptionViewModel = subscription.Data;
        EditSubscriptionViewModel model = new EditSubscriptionViewModel
        {
            Id = subscriptionViewModel.Id,
            Name = subscriptionViewModel.Name,
            Description = subscriptionViewModel.Description,
            Price = subscriptionViewModel.Price,
            SubscriptionType = subscriptionViewModel.SubscriptionType,
            Duration = subscriptionViewModel.Duration,
            DurationUnit = subscriptionViewModel.DurationUnit
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditSubscriptionViewModel model)
    {
        var result = await _subscriptionManager.UpdateAsync(model);
        if (result.IsSucceeded)
        {
            _notyfService.Success("Abonelik başarıyla güncellenmiştir.");
            return RedirectToAction("Index");
        }
        else
        {
            _notyfService.Error(result.Error);
            return View(model);
        }
    }

    public async Task<IActionResult> HardDelete(int id)
    {
        await _subscriptionManager.HardDeleteAsync(id);
        _notyfService.Success("Abonelik kalıcı olarak silinmiştir.");
        return RedirectToAction("Index");
    }
    
}
