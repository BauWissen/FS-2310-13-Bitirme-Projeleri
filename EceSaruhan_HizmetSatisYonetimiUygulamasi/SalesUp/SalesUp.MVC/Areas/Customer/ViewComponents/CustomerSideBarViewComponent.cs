using Microsoft.AspNetCore.Mvc;

namespace SalesUp.MVC.Areas.Customer.ViewComponents;

public class CustomerSideBarViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}