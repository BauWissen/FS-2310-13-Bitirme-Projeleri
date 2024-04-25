using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeamTask.API.AuthorHelper;
using TeamTask.Entity.Concrete;
using TeamTask.Entity.Concrete.Identity;
using TeamTask.Shared.AdminDTOs.User;
using TeamTask.Shared.Response;

namespace TeamTask.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : AuthorAdmin
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public AdminController(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpGet("GetUserList")]
        public async Task<IActionResult> GetUserList()
        {
            var userList = _userManager.Users.ToList();
            var mappedUserList = _mapper.Map<List<A_UserDTO>>(userList);

            return Ok(APIResponse<List<A_UserDTO>>.Success("başarılı", mappedUserList));
        }
        [HttpPost("EditUser")]
        public async Task<IActionResult> EditUser(  A_EditUserDTO info)
        {

            var user = info;
            var foundUser = await _userManager.FindByIdAsync(user.Id);
            //will be fixed 
            foundUser.PhoneNumber = info.PhoneNumber;
            foundUser.UserName = info.UserName;
            foundUser.PhoneNumberConfirmed = info.PhoneNumberConfirmed;
            foundUser.EmailConfirmed = info.EmailConfirmed;
            foundUser.LockoutEnabled = info.LockoutEnabled;
            foundUser.TwoFactorEnabled = info.TwoFactorEnabled;
            foundUser.Email = info.Email;

           var result = await _userManager.UpdateAsync(foundUser);
            if (result.Succeeded  )
                return Ok(APIResponse<NoContent>.Success("Kullanıcı değiştirme başarılı"));

            return Ok(APIResponse<NoContent>.Fail("Bir sorun oluştu"));


        }
        [HttpPost("ToggleConfirmUserEmail")]
        public async Task<IActionResult> ToggleConfirmUserEmail([FromBody] string userId)
        {
            var foundUser = await _userManager.FindByIdAsync(userId);
            foundUser.EmailConfirmed = !foundUser.EmailConfirmed;

            var result = await _userManager.UpdateAsync(foundUser);
            if (result.Succeeded)
                return Ok(APIResponse<NoContent>.Success("Email durumu başarılı şekilde değiştirilmiştir"));


            return Ok(APIResponse<NoContent>.Success("Bir hata oluştu"));

        }
        [HttpPost("RemoveUser")]
        public async Task<IActionResult> RemoveUser([FromBody] string userId)
        {
            var foundUser = await _userManager.FindByIdAsync(userId);


            var result = await _userManager.DeleteAsync(foundUser);

            if (result.Succeeded)
                return Ok(APIResponse<NoContent>.Success("başarılı"));

            return Ok(APIResponse<NoContent>.Fail("başarısız"));
        }
        [HttpGet("GetDataTest")]
        public async Task<IActionResult> GetDataTest()
        {


            return Ok(151515);

        }
    }
}
