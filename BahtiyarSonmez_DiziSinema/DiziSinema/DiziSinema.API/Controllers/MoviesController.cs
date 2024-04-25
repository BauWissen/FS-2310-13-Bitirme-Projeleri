using DiziSinema.Business.Absract;
using DiziSinema.Shared.DTOs.Core.Add;
using DiziSinema.Shared.DTOs.Core.Edit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DiziSinema.Shared.Helpers.Abstract;
using System.Text.Json;
using DiziSinema.Shared.ReponseDTOs;
using DiziSinema.Shared.DTOs;
using AutoMapper;

namespace DiziSinema.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieManager;
        private readonly IImageHelper _imageHelper;


        public MoviesController(IMovieService movieManager, IImageHelper imageHelper)
        {
            _movieManager = movieManager;
            _imageHelper = imageHelper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _movieManager.GetAllAsync();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }


        [HttpGet("GetAllNonDeleted/{isDeleted?}")]
        public async Task<IActionResult> GetAllNonDeleted(bool isDeleted = false)
        {
            var response = await _movieManager.GetAllNonDeletedAsync(isDeleted);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }


        [HttpGet("GetAllWithGenres")]
        public async Task<IActionResult> GetAllWithGenres()
        {
            var response = await _movieManager.GetAllMoviesWithGenresAsync();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _movieManager.GetByIdAsync(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }


        [HttpGet("GetWithGenres/{id}")]
        public async Task<IActionResult> GetWithCategories(int id)
        {
            var response = await _movieManager.GetMovieWithGenresAsync(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }


        [HttpGet("GetByGenreId/{genreId}")]
        public async Task<IActionResult> GetByCategoryId(int genreId)
        {
            var response = await _movieManager.GetMoviesByGenreIdAsync(genreId);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(AddMovieDTO addMovieDTO)
        {
            var respponse = await _movieManager.CreateAsync(addMovieDTO);
            var jsonResponse = JsonSerializer.Serialize(respponse);
            return Ok(jsonResponse);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update(EditMovieDTO editMovieDTO)
        {
            var response = await _movieManager.UpdateAsync(editMovieDTO);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }


        [HttpPost("UpdateIsActive/{id}")]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var response = await _movieManager.UpdateIsActiveAsync(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }


        [HttpDelete("HardDeleted/{id}")]
        public async Task<IActionResult> HardDeleted(int id)
        {
            var response = await _movieManager.HardDeleteAsync(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }


        [HttpGet("SoftDeleted/{id}")]
        public async Task<IActionResult> SoftDeleted(int id)
        {
            var response = await _movieManager.SoftDeleteAsync(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }


        [HttpGet("ActiveCount")]
        public async Task<IActionResult> GetActiveCount()
        {
            var response = await _movieManager.GetActiveMovieCount();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }


        [HttpGet("Count")]
        public async Task<IActionResult> GetCount()
        {
            var response = await _movieManager.GetMovieCount();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }


        [HttpPost("ImageUpload")]
        public async Task<IActionResult> ImageUpload(IFormFile image)
        {
            var response = await _imageHelper.UploadImage(image, "movies");
            return Ok(response);
        }
    }
}
