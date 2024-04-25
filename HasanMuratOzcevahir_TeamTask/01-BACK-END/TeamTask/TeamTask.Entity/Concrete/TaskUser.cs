using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Entity.Concrete.Identity;

namespace TeamTask.Entity.Concrete
{
    public class TaskUser
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }

    }
}
