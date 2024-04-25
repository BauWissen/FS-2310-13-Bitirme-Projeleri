using CosmeticShop.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CosmeticShop.UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productManager;
        private readonly ICategoryService _categoryManager;

        public ProductsController(IProductService productManager, ICategoryService categoryManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
        }

        public async Task<IActionResult> Index(string categoryUrl = null)
        {
            var products =
                String.IsNullOrEmpty(categoryUrl) ?
                await _productManager.GetAllNonDeletedAsync() :
                await _productManager.GetProductsByCategoryUrlAsync(categoryUrl);

            var category = !String.IsNullOrEmpty(categoryUrl) ? await _categoryManager.GetByUrlAsync(categoryUrl) : null;

            ViewBag.CategoryName = category != null ? category.Data.Name : null;

            return View(products.Data);
        }
        
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productManager.GetByIdAsync(id);
            return View(product.Data);
        }
    }
}
