using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTask.Shared.DTOs.Task
{
    public class ChangeTaskStatusDTO
    {
        public int TaskId { get; set; }
        public int StatusId { get; set; }
    }
}
