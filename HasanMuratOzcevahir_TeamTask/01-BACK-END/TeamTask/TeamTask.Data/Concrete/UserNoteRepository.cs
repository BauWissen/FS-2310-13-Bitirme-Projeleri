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
    public class UserNoteRepository:GenericRepository<UserNote>, IUserNoteRepository
    {
        public UserNoteRepository(TeamTaskDBContext _ctx) : base(_ctx) { }
        
            
        
    }
}
