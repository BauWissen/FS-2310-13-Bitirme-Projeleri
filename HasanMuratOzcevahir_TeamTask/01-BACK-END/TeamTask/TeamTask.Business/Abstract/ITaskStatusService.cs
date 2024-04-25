using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Shared.DTOs.Task;

namespace TeamTask.Business.Abstract
{
    public interface ITaskStatusService
    {
        Task<bool> ChangeTaskStatus(ChangeTaskStatusDTO changeTaskStatusDTO);
    }
}
