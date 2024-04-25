using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Business.Abstract;
using TeamTask.Data.Abstract;
using TeamTask.Entity.Concrete;
using TeamTask.Entity.Concrete.Identity;
using TeamTask.Shared.DTOs.Task;
using TeamTask.Shared.DTOs.WorkingSpace;
using TeamTask.Shared.Response;

namespace TeamTask.Business.Concrete
{
    public class TaskManager : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IWorkingSpaceRepository _workingSpaceRepository;
        private readonly IMapper _mapper;


        public TaskManager(ITaskRepository repository, IWorkingSpaceRepository workingSpaceRepository, IMapper mapper)
        {
            _taskRepository = repository;
            _workingSpaceRepository = workingSpaceRepository;
            _mapper = mapper;

        }
        public async Task<APIResponse<List<UserTasksDTO>>> GetAssignedUserTasksAsync(string userId)
        {

            var tasks = await _taskRepository.GetAllAsync(tu => tu.TaskUsers.Any(
                uid => uid.UserId == userId),
                opt =>
            opt
            .Include(w => w.WorkingSpaceTasks)
            .ThenInclude(w => w.WorkingSpace).ThenInclude(wsc => wsc.Comments).ThenInclude(u => u.User)
            .Include(ws => ws.TaskStatus).ThenInclude(s => s.Status)
            .Include(ws => ws.TaskUsers).ThenInclude(u => u.User));
            var mappedtasksDTO = _mapper.Map<List<UserTasksDTO>>(tasks);
            var result = APIResponse<List<UserTasksDTO>>.Success("Başarılı", mappedtasksDTO);
            return result;
        }
        public async Task<int> GetTaskCountAsync(string userId)
        {
            var taskCount = (await _workingSpaceRepository.GetAllAsync(u => u.UserId == userId,
                w => w
                .Include(t => t.WorkingSpaceTasks)
                .ThenInclude(t => t.Task)))
                .Sum(wt => wt.WorkingSpaceTasks.Count);

            return taskCount;
        }
        public async Task<int> GetUsersInTasksCountAsync(string userId)
        {
            var totalUserCount = (await _workingSpaceRepository
               .GetAllAsync(u => u.UserId == userId,
                w => w.Include(t => t.WorkingSpaceTasks)
               .ThenInclude(wst => wst.Task)
               .ThenInclude(t => t.TaskUsers)))
               .SelectMany(w => w.WorkingSpaceTasks)
               .SelectMany(wst => wst.Task.TaskUsers)
               .ToList()
               .Count();
            return totalUserCount;
        }
        public async Task<APIResponse<List<TaskTotalPriorityCountDTO>>> GetTaskTotalOfPriorities(string userId)
        {
            var tasksWithPriority = (await _workingSpaceRepository.GetAllAsync(u => u.UserId == userId, w => w.Include(t => t.WorkingSpaceTasks)
      .ThenInclude(t => t.Task))).SelectMany(w => w.WorkingSpaceTasks)
                .Select(t => t.Task.Priority)
                .GroupBy(p => p)
                .Select(g => new TaskTotalPriorityCountDTO { PriorityKey = Convert.ToByte(g.Key), PriorityCount = g.Count() }).OrderBy(k => k.PriorityKey).ToList();


            return APIResponse<List<TaskTotalPriorityCountDTO>>.Success("başarılı", tasksWithPriority);

        }

        public async Task<APIResponse<CreateTaskDTO>> CreateNewTaskAsync(CreateTaskDTO taskDTO)
        {
            var task = _mapper.Map<Entity.Concrete.Task>(taskDTO);
            var createdTask = await _taskRepository.CreateAsync(task);

            if (createdTask == null)
                return APIResponse<CreateTaskDTO>.Fail("Bir sorun oluştu");

            createdTask.WorkingSpaceTasks = new List<WorkingSpaceTask>
            {
                new() {TaskId = createdTask.Id, WorkingSpaceId = taskDTO.WorkSpaceId}
            };

            createdTask.TaskStatus = new Entity.Concrete.TaskStatus { StatusId = 1, TaskId = createdTask.Id };

            var createResult = await _taskRepository.UpdateAsync(createdTask);

            if (createResult)
            {
                var createTaskDTO = _mapper.Map<CreateTaskDTO>(createdTask);

                return APIResponse<CreateTaskDTO>.Success("Task oluşturuldu", createTaskDTO);
                //no need to return data will fix
            }
            return APIResponse<CreateTaskDTO>.Fail("Bir hata");
        }

        public async Task<APIResponse<NoContent>> AssignUsertoTaskAsync(AssignUserToTaskDTO autDTO)
        {
            var foundTask = await _taskRepository.GetByConditionAsync(t => t.Id == autDTO.TaskId);


            foundTask.TaskUsers = new List<TaskUser> { _mapper.Map<TaskUser>(autDTO) };


            await _taskRepository.UpdateAsync(foundTask);

            return APIResponse<NoContent>.Success($"{foundTask.Title} görevine kullanıcı ekleme işlemi başarılı");
        }
    }
}
