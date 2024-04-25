using Microsoft.AspNetCore.Mvc;
using SalesUp.Business.Abstract;
using SalesUp.Shared.ResponseViewModels;
using SalesUp.Shared.ViewModels;
using SalesUp.Shared.ViewModels.Subscription;

namespace SalesUp.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ISubscriptionService _subscriptionManager;
    private readonly IContactUsService _contactUsManager;

    public HomeController(ISubscriptionService subscriptionManager, IContactUsService contactUsManager)
    {
        _subscriptionManager = subscriptionManager;
        _contactUsManager = contactUsManager;
    }

    public async Task<IActionResult> Index()
    {
        Response<List<SubscriptionViewModel>> subscriptions = await _subscriptionManager.GetAllAsync();
        return View(subscriptions.Data);
    }

}