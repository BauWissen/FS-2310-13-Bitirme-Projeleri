using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Entity.Abstract;
using TeamTask.Entity.Concrete.Identity;

namespace TeamTask.Entity.Concrete
{
    public class WorkingSpaceComment : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string Comment { get; set; }
        public int WorkingSpaceId { get; set; }
    }
}
