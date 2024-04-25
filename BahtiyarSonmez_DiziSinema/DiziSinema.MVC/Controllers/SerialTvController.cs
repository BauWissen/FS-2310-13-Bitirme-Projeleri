using DiziSinema.MVC.Areas.Admin.Models.Movie;
using DiziSinema.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DiziSinema.MVC.Areas.Admin.Models.SerialTv;
using DiziSinema.MVC.Areas.Admin.Models.Genre;
using DiziSinema.MVC.Models.SerialTvViewModels;

namespace DiziSinema.MVC.Controllers
{
    public class SerialTvController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Response<List<SerialTvViewModel>> response = new Response<List<SerialTvViewModel>>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/SerialTvs/GetAllNonDeleted");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<List<SerialTvViewModel>>>(contentResponseApi);
            }
            return View(response.Data);
        }


        [NonAction]
        public async Task<SerialTvViewModel> DetailSerialTvAsync(int id)
        {
            Response<SerialTvViewModel> response = new Response<SerialTvViewModel>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/SerialTv/GetWithGenres/{id}");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<SerialTvViewModel>>(contentResponseApi);
                return response.Data;
            }
        }


        [NonAction]
        public async Task<List<GenreViewModel>> GetGenresAsync()
        {
            Response<List<GenreViewModel>> response = new Response<List<GenreViewModel>>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/Genres");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<List<GenreViewModel>>>(contentResponseApi);
                return response.Data;
            }
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            SerialTvViewModel serialViewModel = await DetailSerialTvAsync(id);
            SerialTvDetailViewModel model = new SerialTvDetailViewModel
            {
                Id = serialViewModel.Id,
                SerName = serialViewModel.SerName,
                Serlanguage = serialViewModel.Serlanguage,
                ImageUrl = serialViewModel.ImageUrl,
                IsActive = serialViewModel.IsActive,
                SerIntro = serialViewModel.SerIntro,
                Url = serialViewModel.Url,
                GenreIds = serialViewModel.GenreList.Select(m => m.Id).ToList(),
                GenreList = await GetGenresAsync()
            };
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Genre(int? id)
        {
            Response<List<SerialTvViewModel>> response = new Response<List<SerialTvViewModel>>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/SerialTv/GetByGenreId/{id}");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<List<SerialTvViewModel>>>(contentResponseApi);
            }
            return View(response.Data);
        }
    }
}
