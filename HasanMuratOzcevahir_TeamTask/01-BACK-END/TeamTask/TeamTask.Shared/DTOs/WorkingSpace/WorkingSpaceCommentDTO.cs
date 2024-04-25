using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Shared.DTOs.User;

namespace TeamTask.Shared.DTOs.WorkingSpace
{
    public class WorkingSpaceCommentDTO
    {
        public int WorkingSpaceId { get; set; }
        public int Id { get; set; }
        public string Comment { get; set; }
        public string CreatedDate { get; set; }
        public string FullName { get; set; }

    }
}
