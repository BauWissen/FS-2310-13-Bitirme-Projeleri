using DiziSinema.MVC.Areas.Admin.Models;
using DiziSinema.MVC.Models.SerialTvViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DiziSinema.MVC.ViewComponents
{
    public class SerialTvMainViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Response<List<SerialTvMainViewModel>> response = new Response<List<SerialTvMainViewModel>>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/SerialTvs");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<List<SerialTvMainViewModel>>>(contentResponseApi);
            }
            return View(response.Data);
        }
    }
}
