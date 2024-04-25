using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TeamTask.API.AuthorHelper;
using TeamTask.Business.Abstract;
using TeamTask.Business.Concrete;
using TeamTask.Entity.Concrete.Identity;
using TeamTask.Shared.DTOs.User;
using TeamTask.Shared.Response;
using TeamTask.Shared.ResponseDTOs;

namespace TeamTask.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IWorkingSpaceService _workingSpaceManager;
        private readonly IUserNoteService _userNoteManager;
        private readonly ITaskService _taskManager;
        private readonly IMapper _mapper;
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IWorkingSpaceService workingSpaceManager, ITaskService taskManager, IUserNoteService userNoteManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _workingSpaceManager = workingSpaceManager;
            _taskManager = taskManager;
            _userNoteManager = userNoteManager;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserDTO newUser)
        {

            User user = new User
            {
                UserName = newUser.Email,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, newUser.Password);
           
            if (result.Succeeded)
                return Ok(APIResponse<NoContent>.Success("Kullanıcı oluşturuldu"));
            
            return Ok(APIResponse<NoContent>.Fail("Kullanıcı oluşturma hatası"));
        }
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser(LoginUserDTO userInfo)
        {
            await _signInManager.SignOutAsync();
            var foundUser = await _userManager.FindByEmailAsync(userInfo.Email);
            if (foundUser == null)
                return Ok(APIResponse<NoContent>.Fail("Email veya parola hatalı"));
            var passwordResult = await _userManager.CheckPasswordAsync(foundUser, userInfo.Password);

            if (passwordResult)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(foundUser, userInfo.Password, !userInfo.RememberMe, true);
                if (signInResult.Succeeded)
                {
                    var mappedUser = _mapper.Map<UserDTO>(foundUser);
                    //Thread.Sleep(10000);//for testing slow response
                    return Ok(APIResponse<UserDTO>.Success("Giriş başarılı", mappedUser));
                }
            }
            return Ok(APIResponse<NoContent>.Fail("Email veya parola hatalı"));
        }
        [HttpGet("LogOutUser")]
        public async Task<IActionResult> LogOutUser()
        {
            Response.Cookies.Delete("TTU");
            await _signInManager.SignOutAsync();

            return Ok(APIResponse<NoContent>.Success("Çıkış başarılı"));
        }
        [HttpGet("GetUserStats")]
        public async Task<IActionResult> GetUserStats()
        {
            var uid = _userManager.GetUserId(User);
            UserStatsDTO userStatsDTO = new UserStatsDTO();
            userStatsDTO.TaskCount = await _taskManager.GetTaskCountAsync(uid);
            userStatsDTO.WorkSpaceCount = await _workingSpaceManager.GetWorkingSpaceCountAsync(uid);
            userStatsDTO.UsersInTasksCount = await _taskManager.GetUsersInTasksCountAsync(uid);
            userStatsDTO.TotalOfEachPriority = (await _taskManager.GetTaskTotalOfPriorities(GetUserId())).Data;
            userStatsDTO.NoteList = (await _userNoteManager.GetUserAllNoteAsync(uid)).Data;
            return Ok(APIResponse<UserStatsDTO>.Success("başarılı", userStatsDTO));
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {

            var userList = _userManager.Users.Where(u => u.Id != GetUserId()).ToList();//assigned user will not be added

            var mappedUserList = _mapper.Map<List<UserForTaskAssignDTO>>(userList);


            return Ok(APIResponse<List<UserForTaskAssignDTO>>.Success("başarılı",mappedUserList));
        }

        [NonAction]
        private string GetUserId()
        {
            return _userManager.GetUserId(User);
        }
    }

}
