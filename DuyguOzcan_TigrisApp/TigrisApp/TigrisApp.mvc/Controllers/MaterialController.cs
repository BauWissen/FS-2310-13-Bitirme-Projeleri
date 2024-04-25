using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TigrisApp.mvc.Controllers
{

    public class MaterialController : Controller
    {
        private readonly ILogger<MaterialController> _logger;

        public MaterialController(ILogger<MaterialController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}