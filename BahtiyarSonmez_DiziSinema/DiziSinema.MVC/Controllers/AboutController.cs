using Microsoft.AspNetCore.Mvc;

namespace DiziSinema.MVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
