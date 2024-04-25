using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeamTask.API.AuthorHelper;
using TeamTask.Business.Abstract;
using TeamTask.Entity.Concrete.Identity;
using TeamTask.Shared.DTOs.WorkingSpace;
using TeamTask.Shared.Response;

namespace TeamTask.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkingSpaceController : AuthorUser
    {
        private readonly IWorkingSpaceService _workingSpaceManager;
        private readonly UserManager<User> _userManager;
        public WorkingSpaceController(IWorkingSpaceService workingSpaceManager, UserManager<User> userManager)
        {
            _workingSpaceManager = workingSpaceManager;
            _userManager = userManager;
        }

        [HttpPost("CreateWorkingSpace")]
        public async Task<IActionResult> CreateWorkingSpace(CreateWorkingSpaceDTO dto)
        {
            dto.UserId = GetUserId();
            var response = await _workingSpaceManager.CreateAsync(dto);
            return Ok(response);
        }
      
        [HttpGet("GetWorkingSpaceByUserIdAsync")]
        public async Task<IActionResult> GetWorkingSpaceByUserIdAsync()
        {
            var foundUserId = GetUserId();
            if (foundUserId == null)
                return Ok("hata");

            var workingSpaces = await _workingSpaceManager.GetAllByUserIdAsync(foundUserId);

            //Thread.Sleep(3000); //for late response
            return Ok(workingSpaces);
        }

        [HttpGet("GetAllWorkingSpaceDetailsByUserIdAsync")]
        public async Task<IActionResult> GetAllWorkingSpaceDetailsByUserIdAsync()
        {
            var foundUserId = GetUserId();
            if (foundUserId == null)
                return Ok("hata");
            var workingSpaceDetail = await _workingSpaceManager.GetAllWorkingSpaceDetailsAsync(foundUserId);

            return Ok(workingSpaceDetail);
        }
       

        [NonAction]
        private string GetUserId()
        {
            return _userManager.GetUserId(User);
        }

    }
}
