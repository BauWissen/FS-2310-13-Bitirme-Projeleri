using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TigrisApp.Business.Abstract;
using TigrisApp.mvc.Models;

namespace TigrisApp.mvc.Controllers;

public class HomeController : Controller
{
    private readonly IRegionService _regionService;
    

    public HomeController( IRegionService regionService)
    {
        _regionService = regionService;
    }

    public async Task<IActionResult> Index()
    {
        var regions= await _regionService.GetAllAsync();
        return View(regions);
    }
    public IActionResult Contact()
    {
        
        ContactInfo contactInfo = new()
        {
            Title = "Sorularınız İçin Bizimle İletişime Geçin",
            SubTitle = "Bize Ulaşın",
            Description= "Görüşlerinizi bizim için önemli,her konudaki fikirlerinizi merakla bekliyoruz.",
            Adress= "Deniz Caddesi, Göl Sokak, Su Birikintisi Apartmanı",
            Phone= "5555 77 554",
            Email="info@tigris.com"
        };
        return View( contactInfo);
    }

}
