using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Data.Abstract;
using TeamTask.Data.Contexts;
using TeamTask.Entity.Concrete;

namespace TeamTask.Data.Concrete
{
    public class WorkingSpaceRepository:GenericRepository<WorkingSpace>,IWorkingSpaceRepository
    {
        public WorkingSpaceRepository(TeamTaskDBContext _context) : base (_context) { }
      
    }
}
