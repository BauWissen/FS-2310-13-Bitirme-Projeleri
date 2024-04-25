using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TigrisApp.Business.Abstract;
using TigrisApp.Entity.Concrete;
using TigrisApp.Shared.ViewModels;

namespace TigrisApp.mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierService.GetAllAsync();
            return View(suppliers);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddSupplierViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _supplierService.AddAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var supplier = await _supplierService.GetByIdAsync(id);
            UpdateSupplierViewModel model = new()
            {
                Id=supplier.Id,
                Name=supplier.Name,
                Description=supplier.Description,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateSupplierViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _supplierService.UpdateAsync(model);
                return RedirectToAction("Index");
            };
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _supplierService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}