
using TeamTask.Entity.Abstract;
using TeamTask.Shared.Types;

namespace TeamTask.Entity.Concrete
{
    public class UserNote : BaseEntity
    {
        public string UserId { get; set; }
        public string NoteTitle { get; set; }
        public string Content { get; set; }
        public UserNotePriorityType Priority { get; set; }
    }
}
