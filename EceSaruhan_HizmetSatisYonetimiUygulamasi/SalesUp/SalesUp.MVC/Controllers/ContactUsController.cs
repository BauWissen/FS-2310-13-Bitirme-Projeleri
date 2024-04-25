using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesUp.Business.Abstract;
using SalesUp.Shared.ViewModels;

namespace SalesUp.MVC.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _manager;

        public ContactUsController(IContactUsService manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactUsViewModel contactUsViewModel)
        {
            await _manager.CreateAsync(contactUsViewModel);
            return RedirectToAction("Index");
        }
    }
}

