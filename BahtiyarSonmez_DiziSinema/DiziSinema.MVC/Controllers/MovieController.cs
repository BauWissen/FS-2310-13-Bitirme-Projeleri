using DiziSinema.MVC.Areas.Admin.Models.Movie;
using DiziSinema.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DiziSinema.MVC.Models.MovieViewModels;
using DiziSinema.MVC.Models.GenreViewModels;
using DiziSinema.MVC.Areas.Admin.Models.Genre;
using System.Reflection;

namespace DiziSinema.MVC.Controllers
{
    public class MovieController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Response<List<MovieViewModel>> response = new Response<List<MovieViewModel>>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/Movies/GetAllNonDeleted");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<List<MovieViewModel>>>(contentResponseApi);
            }
            return View(response.Data);
        }


        [NonAction]
        public async Task<MovieViewModel> DetailMovieAsync(int id)
        {
            Response<MovieViewModel> response = new Response<MovieViewModel>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/Movies/GetWithGenres/{id}");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<MovieViewModel>>(contentResponseApi);
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
            MovieViewModel movieViewModel = await DetailMovieAsync(id);
            EditMovieViewModel model = new EditMovieViewModel
            {
                Id = movieViewModel.Id,
                MovName = movieViewModel.MovName,
                Movlanguage = movieViewModel.Movlanguage,
                ImageUrl = movieViewModel.ImageUrl,
                IsActive = movieViewModel.IsActive,
                MovIntro = movieViewModel.MovIntro,
                Url = movieViewModel.Url,
                GenreIds = movieViewModel.GenreList.Select(m => m.Id).ToList(),
                GenreList = await GetGenresAsync()
            };
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Genre(int? id)
        {
            Response<List<MovieViewModel>> response = new Response<List<MovieViewModel>>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/Movies/GetByGenreId/{id}");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<List<MovieViewModel>>>(contentResponseApi);
            }
            return View(response.Data);
        }
    }
}