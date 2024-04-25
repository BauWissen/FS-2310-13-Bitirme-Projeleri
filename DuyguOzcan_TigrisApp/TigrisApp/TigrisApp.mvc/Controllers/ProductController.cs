using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TigrisApp.mvc.Controllers
{
    
    public class ProductController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

      
    }
}