using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Shared.DTOs.Task;

namespace TeamTask.Shared.DTOs.User
{
    public class UserStatsDTO
    {
        public int TaskCount { get; set; }
        public int WorkSpaceCount { get; set; }
        public int UsersInTasksCount { get; set; }
        public List<TaskTotalPriorityCountDTO> TotalOfEachPriority{ get; set; }
        public  List<UserNoteDTO> NoteList { get; set; }
    }
}
