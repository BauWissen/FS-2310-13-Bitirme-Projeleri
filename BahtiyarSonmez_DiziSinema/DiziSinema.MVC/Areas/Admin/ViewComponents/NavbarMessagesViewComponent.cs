using Microsoft.AspNetCore.Mvc;

namespace DiziSinema.MVC.Areas.Admin.ViewComponents
{
    public class NavbarMessagesViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
