using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SalesUp.Business.Abstract;
using SalesUp.Business.Concrete;
using SalesUp.Entity.Identity;
using SalesUp.Shared.ViewModels.Sale;
using SalesUp.Shared.ViewModels.STask;

namespace SalesUp.MVC.Areas.Customer.Controllers
{
    [Authorize(Roles = "Customer")]
    [Area("Customer")]
    public class SaleController : Controller
    {
        private readonly ISaleService _saleManager;
        private readonly UserManager<User> _userManager;
        private readonly INotyfService _notyfService;
        private readonly IMapper _mapper;

        public SaleController(ISaleService saleManager, UserManager<User> userManager, INotyfService notyfService, IMapper mapper)
        {
            _saleManager = saleManager;
            _userManager = userManager;
            _notyfService = notyfService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var sales = await _saleManager.GetSalesByUserIdAsync(userId);
            return View(sales.Data);
        }

        public async Task<IActionResult> UpdateIsCompleted(int id)
        {
            var result = await _saleManager.UpdateIsCompletedAsync(id);
            var sale = await _saleManager.GetByIdAsync(id);
            return Json(sale.Data.IsCompleted);
        }
        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddSaleViewModel addSaleViewModel)
        {
            var userId = _userManager.GetUserId(User);
            addSaleViewModel.UserId = userId;

            var result = await _saleManager.CreateAsync(addSaleViewModel);
            if (result.IsSucceeded)
            {
                _notyfService.Success("Satış işlemi başarıyla kaydedildi.");
                return RedirectToAction("Index");
            }
            else
            {
                _notyfService.Error(result.Error);
                return View(addSaleViewModel);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var sale = await _saleManager.GetByIdAsync(id);
            var userId = _userManager.GetUserId(User);

            SaleViewModel saleViewModel = sale.Data;
            EditSaleViewModel model = new EditSaleViewModel
            {
                Id = saleViewModel.Id,
                CompletedDate = saleViewModel.CompletedDate,
                IsCompleted = saleViewModel.IsCompleted,
                Note = saleViewModel.Note,
                CustomerName = saleViewModel.CustomerName,
                ProductName = saleViewModel.ProductName,
                CreatedDate = saleViewModel.CreatedDate,
                Unit = saleViewModel.Unit,
                UnitPrice = saleViewModel.UnitPrice,
                Amount = saleViewModel.Amount,
                UserId = saleViewModel.UserId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditSaleViewModel editSaleViewModel)
        {
            var result = await _saleManager.UpdateAsync(editSaleViewModel);
            if (result.IsSucceeded)
            {
                _notyfService.Success("Satış işlemi başarıyla güncellenmiştir.");
                return RedirectToAction("Index");
            }
            else
            {
                _notyfService.Error(result.Error);
                return View(editSaleViewModel);
            }
        }

        public async Task<IActionResult> HardDelete(int id)
        {
            await _saleManager.HardDeleteAsync(id);
            _notyfService.Success("Satış işlemi başarıyla silinmiştir.");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAllSales()
        {
            var userId = _userManager.GetUserId(User);
            await _saleManager.DeleteAllAsync(userId);
            _notyfService.Success("Tüm satış işlemleri başarıyla silinmiştir.");
            return RedirectToAction("Index");
        }
    }
}

