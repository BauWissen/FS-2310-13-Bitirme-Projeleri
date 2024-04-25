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
    public class MaterialController : Controller
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        public async Task<IActionResult> Index()
        {
            var materials = await _materialService.GetAllAsync();
            return View(materials);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddMaterialViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _materialService.AddAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var material = await _materialService.GetByIdAsync(id);
            UpdateMaterialViewModel model= new()
            {
                Id= material.Id,
                Name=material.Name,
                Description=material.Description,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateMaterialViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _materialService.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _materialService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}