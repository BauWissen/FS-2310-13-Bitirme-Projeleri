using CosmeticShop.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CosmeticShop.UI.Controllers
{
    public class HomeController : Controller
    {
      private readonly IProductService _productManager;

        public HomeController(IProductService productManager)
        {
            _productManager = productManager;
        }

        public async Task<IActionResult> Index()
        {
           var products = await _productManager.GetAllNonDeletedAsync(false);
            return View(products.Data);
        }
    }
}
