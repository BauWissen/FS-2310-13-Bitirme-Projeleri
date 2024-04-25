using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Shared.DTOs.Task;


namespace TeamTask.Shared.DTOs.WorkingSpace
{
    public class WorkingSpaceDTO
    {
        public int Id{ get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<UnDetailedTaskDTO> TaskList { get; set; }
      
    
    }
}
