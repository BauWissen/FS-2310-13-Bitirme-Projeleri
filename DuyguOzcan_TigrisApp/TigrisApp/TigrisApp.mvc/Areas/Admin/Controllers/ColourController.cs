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
    public class ColourController : Controller
    {
        private readonly IColourService _colourService;

        public ColourController(IColourService colourService)
        {
            _colourService = colourService;
        }

        public async Task<IActionResult> Index()
        {
            var colours= await _colourService.GetAllAsync();
            return View(colours);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddColourViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _colourService.AddAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var colour =await _colourService.GetByIdAsync(id);
            UpdateColourViewModel model= new()
            {
                Id= colour.Id,
                Name= colour.Name,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateColourViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _colourService.UpdateAsync(model);
                return RedirectToAction ("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _colourService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}