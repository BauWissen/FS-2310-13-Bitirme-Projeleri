using Microsoft.AspNetCore.Mvc;

namespace DiziSinema.MVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
