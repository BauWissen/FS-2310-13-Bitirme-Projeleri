using Microsoft.AspNetCore.Mvc;

namespace IsKapisi.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class JobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
