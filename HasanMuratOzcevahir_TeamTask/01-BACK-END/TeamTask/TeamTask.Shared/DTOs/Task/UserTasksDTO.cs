using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Shared.DTOs.User;
using TeamTask.Shared.DTOs.WorkingSpace;
using TeamTask.Shared.Types;

namespace TeamTask.Shared.DTOs.Task
{
    public class UserTasksDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsOver { get; set; }
        public TaskPriorityType Priority { get; set; }
        public List<WorkingSpaceCommentDTO> SpaceComments { get; set; }
        public StatusDTO Status { get; set; }
        public string WorkingSpaceTitle { get; set; }

    }
}
