using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeamTask.API.AuthorHelper;
using TeamTask.Business.Abstract;
using TeamTask.Entity.Concrete.Identity;
using TeamTask.Shared.DTOs.User;

namespace TeamTask.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NoteController : AuthorUser
    {
        private readonly IUserNoteService _userNoteManager;
        private readonly UserManager<User> _userManager;
        public NoteController(IUserNoteService userNoteManager, UserManager<User> userManager)
        {
            _userNoteManager = userNoteManager;
            _userManager = userManager;
        }
        [HttpPost("CreateNote")]
        public async Task<IActionResult> CreateNote(NoteDTO dto)
        {
            dto.UserId = GetUserId();
            var result = await _userNoteManager.CreateUserNoteAsync(dto);
            return Ok(result); 
        }

        [NonAction]
        private string GetUserId()
        {
            return _userManager.GetUserId(User);
        }
    }
}
