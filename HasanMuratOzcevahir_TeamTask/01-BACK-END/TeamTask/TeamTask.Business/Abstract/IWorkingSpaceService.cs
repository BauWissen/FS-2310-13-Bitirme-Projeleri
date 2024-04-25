using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Entity.Concrete;
using TeamTask.Shared.DTOs.WorkingSpace;
using TeamTask.Shared.Response;

namespace TeamTask.Business.Abstract
{
    public interface IWorkingSpaceService
    {
        Task<APIResponse<WorkingSpaceDTO>> CreateAsync(CreateWorkingSpaceDTO createWorkingSpaceDTO);
        Task<APIResponse<List<WorkingSpaceDTO>>> GetAllByUserIdAsync(string userId);
        Task<APIResponse<List<WorkingSpaceDetailDTO>>> GetAllWorkingSpaceDetailsAsync(string userId);
       
        Task<int> GetWorkingSpaceCountAsync(string userId);
    }
}
