using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TeamTask.Shared.Types;

namespace TeamTask.Shared.DTOs.User
{
    public class UserNoteDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        public string UserId { get; set; }
        public string NoteTitle { get; set; }
        public string Content { get; set; }
        public string PriorityColor { get; set; }
        public string PriorityText { get; set; }
        public UserNotePriorityType Priority { get; set; }
    }
}
