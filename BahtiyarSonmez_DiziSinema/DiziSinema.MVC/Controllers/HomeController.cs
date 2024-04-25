using DiziSinema.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DiziSinema.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
