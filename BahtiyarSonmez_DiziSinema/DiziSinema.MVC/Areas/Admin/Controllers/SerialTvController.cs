using DiziSinema.MVC.Areas.Admin.Models.Genre;
using DiziSinema.MVC.Areas.Admin.Models.Movie;
using DiziSinema.MVC.Areas.Admin.Models;
using DiziSinema.MVC.Extensions;
using DiziSinema.MVC.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using DiziSinema.MVC.Areas.Admin.Models.SerialTv;
using Microsoft.AspNetCore.Authorization;

namespace DiziSinema.MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    [Area("Admin")]
    public class SerialTvController : Controller
    {
        public async Task<IActionResult> Index(bool id = false)
        {
            Response<List<SerialTvViewModel>> response = new Response<List<SerialTvViewModel>>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/SerialTvs/GetAllNonDeleted/{id}");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<List<SerialTvViewModel>>>(contentResponseApi);
            }
            ViewBag.SerialTvShowDeleted = id;
            return View(response.Data);
        }


        public async Task<IActionResult> UpdateIsActive(int id)
        {
            HttpClient httpClient = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://localhost:4100/SerialTvs/UpdateIsActive/{id}"),
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
            AddSerialTvViewModel model = new AddSerialTvViewModel
            {
                GenreList = await GetGenresAsync()
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(AddSerialTvViewModel model, IFormFile image)
        {
            model.Url = Jobs.GetUrl(model.SerName);

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
                        HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("http://localhost:4100/SerialTvs/ImageUpload", imageContent);
                        string httpResponseMessageImageUrl = await httpResponseMessage.Content.ReadAsStringAsync();
                        if (httpResponseMessageImageUrl != null && httpResponseMessageImageUrl != "")
                        {
                            model.ImageUrl = httpResponseMessageImageUrl;
                            //Product Kayıt İşlemi
                            var serializeModel = JsonSerializer.Serialize(model);
                            StringContent stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
                            var result = await httpClient.PostAsync("http://localhost:4100/SerialTvs/Create", stringContent);
                            if (result.IsSuccessStatusCode)
                            {
                                return RedirectToAction("Index");
                            }
                        }
                    }
                }
            }
            ViewBag.GenreErrorMessage = model.GenreIds.Count == 0 ? "Herhangi bir Tür seçmeden, Dizi kaydı yapılamaz" : null;
            ViewBag.ImageErrorMessage = model.ImageUrl == null || model.ImageUrl == "" ? "Resim hatalı!" : null;
            model.GenreList = await GetGenresAsync();

            return View(model);
        }


        [NonAction]
        public async Task<SerialTvViewModel> GetSerialTvAsync(int id)
        {
            Response<SerialTvViewModel> response = new Response<SerialTvViewModel>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/SerialTvs/GetWithGenres/{id}");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<SerialTvViewModel>>(contentResponseApi);
            }
            return response.Data;
        }


        [NonAction]
        public async Task<SerialTvViewModel> GetByIdAsync(int id)
        {
            Response<SerialTvViewModel> response = new Response<SerialTvViewModel>();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/SerialTvs/{id}");
                string contentResponseApi = await responseApi.Content.ReadAsStringAsync();
                response = JsonSerializer.Deserialize<Response<SerialTvViewModel>>(contentResponseApi);
            }
            return response.Data;
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {


            SerialTvViewModel SerialTvViewModel = await GetSerialTvAsync(id);
            EditSerialTvViewModel model = new EditSerialTvViewModel
            {
                Id = SerialTvViewModel.Id,
                SerName = SerialTvViewModel.SerName,
                Serlanguage = SerialTvViewModel.Serlanguage,
                ImageUrl = SerialTvViewModel.ImageUrl,
                IsActive = SerialTvViewModel.IsActive,
                SerIntro = SerialTvViewModel.SerIntro,
                Url = SerialTvViewModel.Url,
                GenreIds = SerialTvViewModel.GenreList.Select(s => s.Id).ToList(),
                GenreList = await GetGenresAsync()
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditSerialTvViewModel model, IFormFile image, string oldImageUrl)
        {

            model.Url = Jobs.GetUrl(model.SerName);

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
                            imageContent.Add(new ByteArrayContent(bytes), "serial", image.FileName);
                            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("http://localhost:4100/SerialTvs/ImageUpload", imageContent);
                            string httpResponseMessageImageUrl = await httpResponseMessage.Content.ReadAsStringAsync();
                            if (httpResponseMessageImageUrl != null && httpResponseMessageImageUrl != "")
                            {
                                model.ImageUrl = httpResponseMessageImageUrl;

                            }
                        }




                        var serializeModel = JsonSerializer.Serialize(model);
                        StringContent stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
                        var result = await httpClient.PutAsync("http://localhost:4100/SerialTvs/Update", stringContent);
                        if (result.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }


                    }
                }
            }
            ViewBag.CategoryErrorMessage = model.GenreIds.Count == 0 ? "Herhangi bir Tür seçmeden, ürün kaydı yapılamaz" : null;
            model.GenreList = await GetGenresAsync();
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Deleted(int id)
        {
            SerialTvViewModel serialTvViewModel = await GetByIdAsync(id);
            DeletedSerialTvViewModel model = new DeletedSerialTvViewModel
            {
                Id = serialTvViewModel.Id,
                SerName = serialTvViewModel.SerName,
                Serlanguage = serialTvViewModel.Serlanguage,
                CreatedDate = serialTvViewModel.CreatedDate,
                ModifiedDate = serialTvViewModel.ModifiedDate,
                IsDeleted = serialTvViewModel.IsDeleted,
            };
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> HardDeleted(int id)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.DeleteAsync($"http://localhost:4100/SerialTvs/HardDeleted/{id}");
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> SoftDeleted(int id)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage responseApi = await httpClient.GetAsync($"http://localhost:4100/SerialTvs/SoftDeleted/{id}");
            }
            var serialTvViewModel = await GetByIdAsync(id);
            return Redirect($"/Admin/SerialTv/Index/{!serialTvViewModel.IsDeleted}");
        }
    }
}
