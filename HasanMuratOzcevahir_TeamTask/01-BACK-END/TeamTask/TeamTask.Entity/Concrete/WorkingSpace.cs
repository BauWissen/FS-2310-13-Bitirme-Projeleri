using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Entity.Abstract;

namespace TeamTask.Entity.Concrete
{
    public class WorkingSpace : BaseEntity
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public List<WorkingSpaceTask> WorkingSpaceTasks { get; set; }
        public List<WorkingSpaceComment> Comments { get; set; }

    }
}
