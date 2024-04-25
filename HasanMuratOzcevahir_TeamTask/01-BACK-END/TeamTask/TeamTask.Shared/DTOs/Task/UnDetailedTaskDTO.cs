using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Shared.DTOs.User;
using TeamTask.Shared.Types;

namespace TeamTask.Shared.DTOs.Task
{
    public class UnDetailedTaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string EndDate { get; set; }
        public bool IsUserAssigned { get; set; }
      
        public bool IsOver { get; set; }
     
     
    }
}
