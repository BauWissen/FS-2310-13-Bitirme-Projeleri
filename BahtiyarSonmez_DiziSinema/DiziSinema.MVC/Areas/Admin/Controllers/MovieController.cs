using DiziSinema.MVC.Areas.Admin.Models.Movie;
using DiziSinema.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using DiziSinema.MVC.Areas.Admin.Models.Genre;
using DiziSinema.MVC.Helpers;
using DiziSinema.MVC.Extensions;
using Microsoft.AspNetCore.Authorization;


namespace DiziSinema.MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    [Area("Admin")]
    public class MovieController : Controller
    {
        public async Task<IActionResult> Index(bool id = false)
        {
            Response<List<MovieViewModel>> response = new Response<List<MovieViewModel>>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/Movies/GetAllNonDeleted/{id}");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<List<MovieViewModel>>>(contentResponseApi);
            }
            ViewBag.MovieShowDeleted = id;
            return View(response.Data);
        }


        public async Task<IActionResult> UpdateIsActive(int id)
        {
            HttpClient httpClient = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://localhost:4100/Movies/UpdateIsActive/{id}"),
                Content = new StringContent("", Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = await httpClient.SendAsync(request);

            return RedirectToAction("Index");
        }


        [NonAction]
        public async Task<List<GenreViewModel>> GetGenresAsync()
        {
            Response<List<GenreViewModel>> response = new Response<List<GenreViewModel>>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync("http://localhost:4100/Genres");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<List<GenreViewModel>>>(contentResponseApi);
            }
            return response.Data;
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            AddMovieViewModel model = new AddMovieViewModel
            {
                GenreList = await GetGenresAsync()
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(AddMovieViewModel model, IFormFile image)
        {
            model.Url = Jobs.GetUrl(model.MovName);

            if (ModelState.IsValid && model.GenreIds.Count > 0 && image != null)
            {
                using (var httpClient = new HttpClient())
                {
                    //Resim Yükleme İşlemi
                    using (var stream = image.OpenReadStream())
                    {
                        var imageContent = new MultipartFormDataContent();
                        byte[] bytes = stream.ToByteArray();
                        imageContent.Add(new ByteArrayContent(bytes), "image", image.FileName);
                        HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("http://localhost:4100/Movies/ImageUpload", imageContent);
                        string httpResponseMessageImageUrl = await httpResponseMessage.Content.ReadAsStringAsync();
                        if (httpResponseMessageImageUrl != null && httpResponseMessageImageUrl != "")
                        {
                            model.ImageUrl = httpResponseMessageImageUrl;
                            //Product Kayıt İşlemi
                            var serializeModel = JsonSerializer.Serialize(model);
                            StringContent stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
                            var result = await httpClient.PostAsync("http://localhost:4100/Movies/Create", stringContent);
                            if (result.IsSuccessStatusCode)
                            {
                                return RedirectToAction("Index");
                            }
                        }
                    }
                }
            }
            ViewBag.MovieGenreErrorMessage = model.GenreIds.Count == 0 ? "Herhangi bir kategori seçmeden, ürün kaydı yapılamaz" : null;
            ViewBag.MovieImageErrorMessage = model.ImageUrl == null || model.ImageUrl == "" ? "Resim hatalı!" : null;
            model.GenreList = await GetGenresAsync();

            return View(model);
        }


        [NonAction]
        public async Task<MovieViewModel> GetMovieAsync(int id)
        {
            Response<MovieViewModel> response = new Response<MovieViewModel>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/Movies/GetWithGenres/{id}");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<MovieViewModel>>(contentResponseApi);
            }
            return response.Data;
        }


        [NonAction]
        public async Task<MovieViewModel> GetByIdAsync(int id)
        {
            Response<MovieViewModel> response = new Response<MovieViewModel>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/Movies/{id}");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<MovieViewModel>>(contentResponseApi);
            }
            return response.Data;
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            MovieViewModel movieViewModel = await GetMovieAsync(id);
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


        [HttpPost]
        public async Task<IActionResult> Edit(EditMovieViewModel model, IFormFile image, string oldImageUrl)
        {

            model.Url = Jobs.GetUrl(model.MovName);

            if (ModelState.IsValid && model.GenreIds.Count > 0)
            {
                using (var httpClient = new HttpClient())
                {

                    //Resim Yükleme İşlemi
                    using (var stream = image != null ? image.OpenReadStream() : null)
                    {
                        if (image != null)
                        {
                            var imageContent = new MultipartFormDataContent();
                            byte[] bytes = stream.ToByteArray();
                            imageContent.Add(new ByteArrayContent(bytes), "image", image.FileName);
                            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("http://localhost:4100/Movies/ImageUpload", imageContent);
                            string httpResponseMessageImageUrl = await httpResponseMessage.Content.ReadAsStringAsync();
                            if (httpResponseMessageImageUrl != null && httpResponseMessageImageUrl != "")
                            {
                                model.ImageUrl = httpResponseMessageImageUrl;
                            }
                        }

                        var serializeModel = JsonSerializer.Serialize(model);
                        StringContent stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
                        var result = await httpClient.PutAsync("http://localhost:4100/Movies/Update", stringContent);
                        if (result.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
            ViewBag.GenreErrorMessage = model.GenreIds.Count == 0 ? "Herhangi bir kategori seçmeden, ürün kaydı yapılamaz" : null;
            model.GenreList = await GetGenresAsync();
            return View(model);
        }


        
        [HttpGet]
        public async Task<IActionResult> Deleted(int id)
        {
            MovieViewModel movieViewModel = await GetByIdAsync(id);
            DeletedMovieViewModel model = new DeletedMovieViewModel
            {
                Id = movieViewModel.Id,
                MovName = movieViewModel.MovName,
                Movlanguage = movieViewModel.Movlanguage,
                CreatedDate = movieViewModel.CreatedDate,
                ModifiedDate = movieViewModel.ModifiedDate,
                IsDeleted = movieViewModel.IsDeleted,
            };
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> HardDeleted(int id)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.DeleteAsync($"http://localhost:4100/Movies/HardDeleted/{id}");
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> SoftDeleted(int id)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/Movies/SoftDeleted/{id}");
            }
            var movieViewModel = await GetByIdAsync(id);
            return Redirect($"/Admin/Movie/Index/{!movieViewModel.IsDeleted}");
        }
    }
}
