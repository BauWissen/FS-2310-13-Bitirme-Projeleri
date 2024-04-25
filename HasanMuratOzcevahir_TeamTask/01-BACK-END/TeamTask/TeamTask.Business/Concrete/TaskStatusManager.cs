using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Business.Abstract;
using TeamTask.Data.Abstract;
using TeamTask.Shared.DTOs.Task;

namespace TeamTask.Business.Concrete
{
    public class TaskStatusManager : ITaskStatusService
    {
        private readonly ITaskStatusRepository _taskStatusRepository;
        private readonly IMapper _mapper;

        public TaskStatusManager(ITaskStatusRepository taskStatusRepository, IMapper mapper)
        {
            _taskStatusRepository = taskStatusRepository;
            _mapper = mapper;
        }

        public async Task<bool> ChangeTaskStatus(ChangeTaskStatusDTO changeTaskStatusDTO)
        {
            var changedTaskStatus = _mapper.Map<Entity.Concrete.TaskStatus>(changeTaskStatusDTO);

            
            var willchange = await _taskStatusRepository.GetByConditionAsync(x=> x.TaskId == changeTaskStatusDTO.TaskId);

            await _taskStatusRepository.HardDeleteAsync(willchange);
          

           await _taskStatusRepository.CreateAsync(changedTaskStatus);

            return true;


        }
    }
}
