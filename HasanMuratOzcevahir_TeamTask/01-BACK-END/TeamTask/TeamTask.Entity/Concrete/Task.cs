using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Entity.Abstract;
using TeamTask.Shared.DTOs.WorkingSpace;
using TeamTask.Shared.Types;

namespace TeamTask.Entity.Concrete
{
    public class Task:BaseEntity
    {
        public string Title { get; set; }
        public DateTime EndDate { get; set; }
        public TaskPriorityType Priority { get; set; }
         
        public List<WorkingSpaceTask> WorkingSpaceTasks { get; set; }// need fix, list is unecessary , effects mapping.
   
        public TaskStatus TaskStatus { get; set; }
        public List<TaskUser> TaskUsers { get; set; }// not sure if a task can have only one user or many.

    }
}
