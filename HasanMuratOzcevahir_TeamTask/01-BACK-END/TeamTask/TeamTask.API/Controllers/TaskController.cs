using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeamTask.API.AuthorHelper;
using TeamTask.Business.Abstract;
using TeamTask.Entity.Concrete.Identity;
using TeamTask.Shared.DTOs.Task;
using TeamTask.Shared.Response;

namespace TeamTask.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : AuthorUser
    {
        private readonly ITaskService _taskManager;
        private readonly UserManager<User> _userManager;
        private readonly ITaskStatusService _taskStatusManager;

        public TaskController(ITaskService taskManager, UserManager<User> userManager, ITaskStatusService taskStatusManager)
        {
            _taskManager = taskManager;
            _userManager = userManager;
            _taskStatusManager = taskStatusManager;
        }

        [HttpPost("CreateNewTask")]
        public async Task<IActionResult> CreateNewTask(CreateTaskDTO info)
        {
             var result = await _taskManager.CreateNewTaskAsync(info);
            return Ok(APIResponse<CreateTaskDTO>.Success(result.Message, result.Data));
        }
        [HttpPost("AssignUsertoTask")]
        public async Task<IActionResult> AssignUsertoTask(AssignUserToTaskDTO info)
        {
            var result = await _taskManager.AssignUsertoTaskAsync(info);
            return Ok(APIResponse<NoContent>.Success(result.Message));
        }

        [HttpGet("GetUserAssignedTasksAsync")]
        public async Task<IActionResult> GetUserAssignedTasksAsync()
        {
            var result = await _taskManager.GetAssignedUserTasksAsync(GetUserId());
            return Ok(APIResponse<List<UserTasksDTO>>.Success("başarılı",result.Data));

        }
        [HttpPost("ChangeTaskStatus")]
        public async Task<IActionResult> ChangeTaskStatus(ChangeTaskStatusDTO info)
        {
            var inf = await _taskStatusManager.ChangeTaskStatus(info);
            return Ok(true);
        }
        [NonAction]
        private string GetUserId()
        {
            return _userManager.GetUserId(User);
        }

    }
}
