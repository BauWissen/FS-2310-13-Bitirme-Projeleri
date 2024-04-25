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
    public class RegionController : Controller
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        public async Task<IActionResult>  Index()
        {
            var regions = await _regionService.GetAllAsync();
            return View(regions);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddRegionViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _regionService.AddAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var region = await _regionService.GetByIdAsync(id);
            UpdateRegionViewModel model = new()
            {
                Id= region.Id,
                Name=region.Name,
                
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateRegionViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _regionService.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _regionService.DeleteAsync(id);
            return RedirectToAction("Index");
        }


    }
}