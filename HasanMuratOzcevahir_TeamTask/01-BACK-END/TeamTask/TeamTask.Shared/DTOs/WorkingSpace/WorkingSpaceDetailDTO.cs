using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Shared.DTOs.Task;

namespace TeamTask.Shared.DTOs.WorkingSpace
{
    public class WorkingSpaceDetailDTO
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }

        public string Title { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int TaskCount { get; set; }
        public List<TaskDTO> TaskList { get; set; }
        public int CommentCount { get; set; }
        public List<WorkingSpaceCommentDTO> Comments { get; set; }
    }
}
