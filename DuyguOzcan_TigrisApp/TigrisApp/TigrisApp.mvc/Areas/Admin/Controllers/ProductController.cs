using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using TigrisApp.Business.Abstract;
using TigrisApp.Shared.ViewModels;


namespace TigrisApp.mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IColourService _colourService;
        private readonly IMaterialService _materialService;
        private readonly ISupplierService _supplierService;
        private readonly ICategoryService _categoryService;
        private readonly IGenderService _genderService;


        public ProductController(IProductService productService, IColourService colourService, IMaterialService materialService, ISupplierService supplierService, ICategoryService categoryService, IGenderService genderService)
        {
            _productService = productService;
            _colourService = colourService;
            _materialService = materialService;
            _supplierService = supplierService;
            _categoryService = categoryService;
            _genderService = genderService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsWithCategories();
            return View(products);
        }
        public async Task<IActionResult> Create()
        {
            var colours = await _colourService.GetAllAsync();
            var colourList = colours.Select(x => new SelectListItem{
                Text= x.Name,
                Value =x.Id.ToString()
            }).ToList();

            var materials = await _materialService.GetAllAsync();
            var materialList = materials.Select(x=> new SelectListItem{
                Text= x.Name,
                Value = x.Id.ToString()
            }).ToList();

            var suppliers = await _supplierService.GetAllAsync();
            var supplierList = suppliers.Select(x=> new SelectListItem{
                Text= x.Name,
                Value= x.Id.ToString()
            }).ToList();

            var categories = await _categoryService.GetAllAsync();
            var categoryList = categories.Select(x=> new SelectListItem{
                Text=x.Name,
                Value= x.Id.ToString()
            }).ToList();

            var genders = await _genderService.GetAllAsync();
            var genderList = genders.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            AddProductViewModel model= new()
            {
                ColourList= colourList,
                MaterialList= materialList,
                SupplierList = supplierList,
                CategoryList= categoryList,
                GenderList= genderList
            };
            return View(model);
        }
    }
}