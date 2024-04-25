using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesUp.Business.Abstract;
using SalesUp.Business.Concrete;
using SalesUp.Shared.ViewModels;
using SalesUp.Shared.ViewModels.Subscription;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesUp.MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    [Area("Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _manager;
        private readonly INotyfService _notyfService;

        public ContactUsController(IContactUsService manager, INotyfService notyfService)
        {
            _manager = manager;
            _notyfService = notyfService;
        }

        
        public async Task<IActionResult> Index()
        {
            var contacts = await _manager.GetAllAsync();
            return View(contacts.Data);
        }

        public async Task<IActionResult> HardDelete(int id)
        {
            await _manager.HardDeleteAsync(id);
            _notyfService.Success("Kişi başarıyla silinmiştir.");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateIsCompleted(int id)
        {
            var result= await _manager.UpdateIsCompletedAsync(id);
            var contact = await _manager.GetByIdAsync(id);
            return Json(contact.Data.IsCompleted);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task Create(ContactUsViewModel contactUsViewModel)
        {
            await _manager.CreateAsync(contactUsViewModel);
        }
    }
}

