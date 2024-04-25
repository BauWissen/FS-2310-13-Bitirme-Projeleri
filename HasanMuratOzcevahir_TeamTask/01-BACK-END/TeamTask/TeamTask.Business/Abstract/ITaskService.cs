using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Shared.DTOs.Task;
using TeamTask.Shared.DTOs.WorkingSpace;
using TeamTask.Shared.Response;

namespace TeamTask.Business.Abstract
{
    public interface ITaskService
    {
        Task<APIResponse<CreateTaskDTO>> CreateNewTaskAsync(CreateTaskDTO taskDTO);
        Task<APIResponse<NoContent>> AssignUsertoTaskAsync(AssignUserToTaskDTO autDTO);
        /// <summary>
        /// Gets the total count of tasks
        /// </summary>
        /// <param name="userId">Current user who has work spaces</param>
        /// <returns></returns>
        Task<int> GetTaskCountAsync(string userId);
        /// <summary>
        /// Gets the total count of users in tasks
        /// </summary>
        /// <param name="userId">Current user who has work spaces</param>
        /// <returns></returns>
        Task<int> GetUsersInTasksCountAsync(string userId);
        /// <summary>
        /// Gets the assigned tasks of user
        /// </summary>
        /// <param name="userId">User id for tasks</param>
        /// <returns></returns>
        Task<APIResponse<List<UserTasksDTO>>> GetAssignedUserTasksAsync(string userId);
        /// <summary>
        /// Gets the total counts of each priority type
        /// </summary>
        /// <param name="userId">To get tasks who created</param>
        /// <returns></returns>
        Task<APIResponse<List<TaskTotalPriorityCountDTO>>> GetTaskTotalOfPriorities(string userId);

    }
}
