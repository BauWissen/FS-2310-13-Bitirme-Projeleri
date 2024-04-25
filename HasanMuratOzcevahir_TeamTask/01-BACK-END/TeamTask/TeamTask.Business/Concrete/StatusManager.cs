using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Business.Abstract;
using TeamTask.Data.Abstract;
using TeamTask.Shared.DTOs.Task;
using TeamTask.Shared.Response;

namespace TeamTask.Business.Concrete
{
    public class StatusManager : IStatusService
    {

        private readonly IStatusRepository _taskStatusRepository;
        private readonly IMapper _mapper;

        public StatusManager(IStatusRepository taskStatusRepository, IMapper mapper)
        {
            _taskStatusRepository = taskStatusRepository;
            _mapper = mapper;
        }

        public async Task<APIResponse<List<StatusDTO>>> GetAllAsync()
        {
            var result = await _taskStatusRepository.GetAllAsync();

            var taskStatusDTO = _mapper.Map<List<StatusDTO>>(result);

            return APIResponse<List<StatusDTO>>.Success("başarılı", taskStatusDTO);
            
        }
    }
}
