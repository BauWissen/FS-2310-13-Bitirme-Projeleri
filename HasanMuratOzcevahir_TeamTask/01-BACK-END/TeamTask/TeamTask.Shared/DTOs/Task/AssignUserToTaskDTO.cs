using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTask.Shared.DTOs.Task
{
    public class AssignUserToTaskDTO
    {
        public string UserId { get; set; }
        public int TaskId { get; set; }
    }
}
