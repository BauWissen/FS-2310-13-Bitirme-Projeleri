using DiziSinema.MVC.Areas.Admin.Models.Genre;
using DiziSinema.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using DiziSinema.MVC.Helpers;
using DiziSinema.MVC.Extensions;
using Microsoft.AspNetCore.Authorization;


namespace DiziSinema.MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    [Area("Admin")]
    public class GenreController : Controller
    {
        public async Task<IActionResult> Index(bool id= false)
        {
            Response<List<GenreViewModel>> response = new Response<List<GenreViewModel>>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/Genres/NonDeleteds/{id}");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<List<GenreViewModel>>>(contentResponseApi);
            }
            ViewBag.GenreShowDeleted = id;
            return View(response.Data);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            HttpClient httpClient = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://localhost:4100/Genres/UpdateIsActive/{id}"),
                Content = new StringContent("", Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = await httpClient.SendAsync(request);

            return RedirectToAction("Index");
        }

        [NonAction]
        public async Task<GenreViewModel> GetByIdAsync(int id)
        {
            Response<GenreViewModel> response = new Response<GenreViewModel>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/Genres/{id}");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<GenreViewModel>>(contentResponseApi);
            }
            return response.Data;
        }

        [NonAction]
        public async Task<GenreViewModel> GetGenresAsync(int id)
        {
            Response<GenreViewModel> response = new Response<GenreViewModel>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/Genres");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<GenreViewModel>>(contentResponseApi);
            }
            return response.Data;
        }

        [HttpGet]
        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddGenreViewModel model)
        {
            model.Url = Jobs.GetUrl(model.GenreName);
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    var serializeModel = JsonSerializer.Serialize(model);
                    StringContent stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
                    var result = await httpClient.PostAsync("http://localhost:4100/Genres/Create", stringContent);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Deleted(int id)
        {
            GenreViewModel genreViewModel = await GetByIdAsync(id);
            DeletedGenreViewModel model = new DeletedGenreViewModel
            {
                Id = genreViewModel.Id,
                GenreName = genreViewModel.GenreName,
                Description = genreViewModel.Description,
                CreatedDate = genreViewModel.CreatedDate,
                ModifiedDate = genreViewModel.ModifiedDate,
                IsDeleted = genreViewModel.IsDeleted,
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> HardDeleted(int id)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.DeleteAsync($"http://localhost:4100/Genres/HardDeleted/{id}");
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> SoftDeleted(int id)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/Genres/SoftDeleted/{id}");
            }
            var genreViewModel = await GetByIdAsync(id);
            return Redirect($"/Admin/Genre/Index/{!genreViewModel.IsDeleted}");
        }
    }
}
