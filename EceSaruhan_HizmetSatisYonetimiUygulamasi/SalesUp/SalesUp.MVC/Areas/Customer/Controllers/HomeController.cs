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
using SalesUp.Entity.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesUp.MVC.Areas.Customer.Controllers
{
    [Authorize(Roles = "Customer")]
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ISaleService _saleManager;

        public HomeController(ISaleService saleManager)
        {
            _saleManager = saleManager;
        }

        public async Task<IActionResult> Index(bool isCompleted = true)
        {
            var sales = await _saleManager.GetAllCompletedAsync(isCompleted);
         
            return View(sales.Data);
        }
    }
}

