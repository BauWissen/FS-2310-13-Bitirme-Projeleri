using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamTask.API.AuthorHelper;
using TeamTask.Business.Abstract;

namespace TeamTask.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly IStatusService _taskStatusManager;

        public TaskStatusController(IStatusService taskStatusManager)
        {
            _taskStatusManager = taskStatusManager;
        }

        [HttpGet("GetAllTaskStatusTypes")]
        public async Task<IActionResult> GetAllTaskStatusTypes()
        {

            var result = await _taskStatusManager.GetAllAsync();


            return Ok(result);
        }



    }
}
