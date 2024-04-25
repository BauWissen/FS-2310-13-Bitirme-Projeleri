using DiziSinema.MVC.Areas.Admin.Models.Movie;
using DiziSinema.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DiziSinema.MVC.Models.MovieViewModels;

namespace DiziSinema.MVC.ViewComponents
{
    public class MovieMainViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Response<List<MovieMainViewModel>> response = new Response<List<MovieMainViewModel>>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/Movies");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<List<MovieMainViewModel>>>(contentResponseApi);
            }
            return View(response.Data);
        }
    }
}
