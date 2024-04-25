using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TigrisApp.Business.Abstract;

namespace TigrisApp.mvc.ViewComponents
{
    public class RegionViewComponent: ViewComponent
    {
        private readonly IRegionService _regionService;

        public RegionViewComponent(IRegionService regionService)
        {
            _regionService = regionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var regions = await _regionService.GetAllAsync();
            return View(regions);
                
            
        }
    }
}