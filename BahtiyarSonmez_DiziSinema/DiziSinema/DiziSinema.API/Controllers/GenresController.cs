using DiziSinema.Business.Absract;
using DiziSinema.Business.Concrete;
using DiziSinema.Shared.DTOs.Core.Add;
using DiziSinema.Shared.DTOs.Core.Edit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DiziSinema.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreManager;

        public GenresController(IGenreService genreManager)
        {
            _genreManager = genreManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _genreManager.GetAllAsync();
            var jsonSerilaz = JsonSerializer.Serialize(response);
            return Ok(jsonSerilaz);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _genreManager.GetByIdAsync(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(AddGenreDTO addGenreDTO)
        {
            var respponse = await _genreManager.CreateAsync(addGenreDTO);
            var jsonResponse = JsonSerializer.Serialize(respponse);
            return Ok(jsonResponse);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(EditGenreDTO editGenreDTO)
        {
            var response = await _genreManager.UpdateAsync(editGenreDTO);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }

        [HttpDelete("HardDeleted/{id}")]
        public async Task<IActionResult> HardDeleted(int id)
        {
            var response = await _genreManager.HardDeleteAsync(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }

        [HttpGet("SoftDeleted/{id}")]
        public async Task<IActionResult> SoftDeleted(int id)
        {
            var response = await _genreManager.SoftDeleteAsync(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }

        [HttpGet("NonDeleteds/{isDeleted?}")]
        public async Task<IActionResult> GetNonDeleted(bool isDeleted = false)
        {
            var response = await _genreManager.GetNonDeletedGenre(isDeleted);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }

        [HttpGet("Actives/{isActive?}")]
        public async Task<IActionResult> GetActives(bool isActive = true)
        {
            var response = await _genreManager.GetActiveGenre(isActive);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }

        [HttpGet("ActiveCount")]
        public async Task<IActionResult> GetActiveCount()
        {
            var response = await _genreManager.GetActiveGenreCount();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }

        [HttpGet("Count")]
        public async Task<IActionResult> GetCount()
        {
            var response = await _genreManager.GetGenreCount();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }


        [HttpGet("GetGenres")]
        public async Task<IActionResult> GetGenres()
        {
            var response = await _genreManager.GetGenres();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
    }
}
