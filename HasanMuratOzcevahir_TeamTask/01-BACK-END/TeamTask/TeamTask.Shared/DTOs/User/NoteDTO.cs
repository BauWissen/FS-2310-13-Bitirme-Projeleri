using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Shared.Types;

namespace TeamTask.Shared.DTOs.User
{
    public class NoteDTO
    {
        public string? UserId { get; set; }
        public UserNotePriorityType Priority { get; set; }
        public string NoteTitle { get; set; }
        public string Content { get; set; }
    }
}
