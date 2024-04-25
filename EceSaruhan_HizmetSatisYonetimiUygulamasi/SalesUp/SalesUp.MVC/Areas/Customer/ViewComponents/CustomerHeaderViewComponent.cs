using Microsoft.AspNetCore.Mvc;

namespace SalesUp.MVC.Areas.Customer.ViewComponents;

public class CustomerHeaderViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}