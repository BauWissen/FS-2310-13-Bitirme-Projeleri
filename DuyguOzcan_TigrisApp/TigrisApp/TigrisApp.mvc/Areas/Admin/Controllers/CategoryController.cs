using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TigrisApp.Business.Abstract;
using TigrisApp.Shared.ViewModels;

namespace TigrisApp.mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult>  Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }
        
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCategoryViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _categoryService.AddAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var category= await _categoryService.GetByIdAsync(id);
            UpdateCategoryViewModel model = new()
            {
                Id= category.Id,
                Name= category.Name,
                Description= category.Description
            };
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCategoryViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _categoryService.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
           await _categoryService.DeleteAsync(id);
           return RedirectToAction("Index");
        }
    }
}