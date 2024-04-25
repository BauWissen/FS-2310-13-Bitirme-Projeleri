using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTask.Entity.Concrete
{
    public class TaskStatus
    {
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
