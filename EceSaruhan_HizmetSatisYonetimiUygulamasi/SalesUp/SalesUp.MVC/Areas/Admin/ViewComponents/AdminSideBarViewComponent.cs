using Microsoft.AspNetCore.Mvc;

namespace SalesUp.MVC.Areas.Admin.ViewComponents;

public class AdminSideBarViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}