using IsKapisi.Business.Abstract;
using IsKapisi.Core.ViewModels;
using IsKapisi.Entity;
using IsKapisi.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IsKapisi.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobService _jobManager;

        public HomeController(IJobService jobManager)
        {
            _jobManager = jobManager;
        }

        public IActionResult Index()
        {
            var jobs = _jobManager.GetAll(true);
            return View(jobs);
        

        }

        public IActionResult GetById(int id)
        {
            JobViewModel job = _jobManager.GetById(id);
            return View(job);
        }

        public IActionResult MoreJob()
        {
            var jobs = _jobManager.GetAll(true);
            return View(jobs);


        }

        public IActionResult Contact()
        {
            var jobs = _jobManager.GetAll(true);
            return View(jobs);


        }

        public IActionResult Blog()
        {
            var jobs = _jobManager.GetAll(true);
            return View(jobs);


        }

        public IActionResult Blogs()
        {
            var jobs = _jobManager.GetAll(true);
            return View(jobs);


        }










    }
}
