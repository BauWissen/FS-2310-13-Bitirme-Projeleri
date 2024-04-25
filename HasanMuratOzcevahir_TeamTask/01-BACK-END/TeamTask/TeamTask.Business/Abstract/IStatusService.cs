using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Shared.DTOs.Task;
using TeamTask.Shared.Response;

namespace TeamTask.Business.Abstract
{
    public interface IStatusService
    {
        Task<APIResponse<List<StatusDTO>>> GetAllAsync();
    }
}
