using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeamTask.Data.Contexts;
using TeamTask.Entity.Concrete.Identity;

namespace TeamTask.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        public AuthController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet("IsUserAdmin")]
        public async Task<IActionResult> IsUserAdmin()
        {
            Thread.Sleep(2000);

            var findUser = await _userManager.GetUserAsync(User);
            if (findUser == null)
                return Ok();

            var isInRole = await _userManager.GetRolesAsync(findUser);
            if (!isInRole.Contains("Admin"))
                return Ok(new { message = "unauthorized", authorize = false, isAdmin = false });
            return Ok(new { isAdmin = true });
        }
    }
}
