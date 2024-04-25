using Microsoft.AspNetCore.Mvc;

namespace IsKapisi.Mvc.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
