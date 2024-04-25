using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TigrisApp.Business.Abstract;
using TigrisApp.Business.Concrete;

namespace TigrisApp.mvc.ViewComponents
{
    public class ColourViewComponent : ViewComponent
    {
       private readonly IColourService _colourService;
        public ColourViewComponent(IColourService colourService)
        {
            _colourService = colourService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var colours = await _colourService.GetAllAsync();
            return View(colours);
        }
    }
}