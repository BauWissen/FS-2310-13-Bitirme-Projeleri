using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Data.Abstract;
using TeamTask.Data.Contexts;

namespace TeamTask.Data.Concrete
{
    public class TaskStatusRepository:GenericRepository<Entity.Concrete.TaskStatus>, ITaskStatusRepository
    {
        public TaskStatusRepository(TeamTaskDBContext _context) : base(_context) { }    
       
    }
}
