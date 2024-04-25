using DiziSinema.MVC.Areas.Admin.Models;
using DiziSinema.MVC.Areas.Admin.Models.Genre;
using DiziSinema.MVC.Models.GenreViewModels;
using DiziSinema.MVC.Models.MovieViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DiziSinema.MVC.ViewComponents
{
    public class MovieGenreViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Response<List<GenreViewModel>> response = new Response<List<GenreViewModel>>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/Genres/GetGenres");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<List<GenreViewModel>>>(contentResponseApi);
            }
            return View(response.Data);
        }
    }
}
