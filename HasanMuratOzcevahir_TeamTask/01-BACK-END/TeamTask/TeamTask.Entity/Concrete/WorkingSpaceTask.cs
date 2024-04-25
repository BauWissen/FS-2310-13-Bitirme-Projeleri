using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Entity.Abstract;

namespace TeamTask.Entity.Concrete
{
    public class WorkingSpaceTask
    {
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public int WorkingSpaceId { get; set; }
        public WorkingSpace WorkingSpace { get; set; }
     

    }
}
