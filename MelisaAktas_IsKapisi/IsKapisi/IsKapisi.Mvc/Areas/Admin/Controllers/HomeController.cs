using IsKapisi.Business.Abstract;
using IsKapisi.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IsKapisi.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
 

    public class HomeController : Controller
    {
        private readonly IJobService _jobManager;

        public HomeController(IJobService jobManager)
        {
            _jobManager = jobManager;
        }

        public IActionResult Index()
        {
            var jobs = _jobManager.GetAll(null, null, false);
            return View(jobs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(JobViewModel jobViewModel)
        {
            _jobManager.Create(jobViewModel);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            JobViewModel editedJob = _jobManager.GetById(id);
            return View(editedJob);
        }

        [HttpPost]
        public IActionResult Edit(JobViewModel editedJob)
        {
            _jobManager.Update(editedJob);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            JobViewModel deletedJob = _jobManager.GetById(id);
            return View(deletedJob);
        }

        public IActionResult HardDelete(int id)
        {
            _jobManager.HardDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult SoftDelete(int id)
        {
            _jobManager.SoftDelete(id);
            return RedirectToAction("Index");
        }

        
    }
}
