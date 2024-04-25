using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using TeamTask.Business.Abstract;
using TeamTask.Data.Abstract;
using TeamTask.Entity.Concrete;
using TeamTask.Shared.DTOs.WorkingSpace;
using TeamTask.Shared.Response;

namespace TeamTask.Business.Concrete
{
    public class WorkingSpaceManager : IWorkingSpaceService
    {
        private readonly IWorkingSpaceRepository _repository;
        private readonly IMapper _mapper;

        public WorkingSpaceManager(IWorkingSpaceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<APIResponse<WorkingSpaceDTO>> CreateAsync(CreateWorkingSpaceDTO createWorkingSpaceDTO)
        {
            var workingSpace = _mapper.Map<WorkingSpace>(createWorkingSpaceDTO);

            var createdWorkingSpace = await _repository.CreateAsync(workingSpace);
            if (createdWorkingSpace == null)
            {
                return APIResponse<WorkingSpaceDTO>.Fail("Bir sorun oluştu");
            }
            var createdWorkingSpaceDTO = _mapper.Map<WorkingSpaceDTO>(createdWorkingSpace);

            return APIResponse<WorkingSpaceDTO>.Success("Çalışma alanı oluşturuldu", createdWorkingSpaceDTO);
        }

        public async Task<APIResponse<List<WorkingSpaceDTO>>> GetAllByUserIdAsync(string userId)
        {
            var isUsers = false;
            var isComments = false;
            var result = await _repository.GetAllAsync(w => w.UserId == userId,
                w=>w
                    .Include(s => s.WorkingSpaceTasks)
                    .ThenInclude(t => t.Task)
                    .ThenInclude(s => s.TaskStatus)
                    .ThenInclude(st => st.Status)

                        .Include(ws => ws.WorkingSpaceTasks)
                   .ThenInclude(t => t.Task)
                   .ThenInclude(tu => tu.TaskUsers)
                   .ThenInclude(u => u.User)

            );
            var workingSpaceDTO = result != null ? _mapper.Map<List<WorkingSpaceDTO>>(result) : null;

            return APIResponse<List<WorkingSpaceDTO>>.Success("Başarılı", workingSpaceDTO);
        }

        public async Task<APIResponse<List<WorkingSpaceDetailDTO>>> GetAllWorkingSpaceDetailsAsync(string userId)
        {
            var result = await _repository.GetAllAsync(w => w.UserId == userId,
               w =>  
                w.Include(w => w.Comments)

                  .Include(s => s.WorkingSpaceTasks)
                    .ThenInclude(t => t.Task)
                    .ThenInclude(s => s.TaskStatus)
                    .ThenInclude(st => st.Status)

                .Include(ws => ws.WorkingSpaceTasks)
                   .ThenInclude(t => t.Task)
                   .ThenInclude(tu => tu.TaskUsers)
                   .ThenInclude(u => u.User)
           );
            var workingSpaceDTO = result != null ? _mapper.Map<List<WorkingSpaceDetailDTO>>(result) : null;

            return APIResponse<List<WorkingSpaceDetailDTO>>.Success("Başarılı", workingSpaceDTO);
        }

        public async Task<int> GetWorkingSpaceCountAsync(string userId)
        {
            var result = await _repository.GetCount(u => u.UserId == userId);

            return result;
        }
    }
}
