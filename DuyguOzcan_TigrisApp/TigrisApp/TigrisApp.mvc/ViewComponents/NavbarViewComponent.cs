using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TigrisApp.Business.Abstract;

namespace TigrisApp.mvc.ViewComponents
{
    public class NavbarViewComponent :ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public NavbarViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }
    }
}