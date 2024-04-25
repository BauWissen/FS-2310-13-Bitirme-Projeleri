using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTask.Shared.DTOs.WorkingSpace
{
    public class CreateWorkingSpaceDTO
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }
}
