using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Entity.Concrete;
using TeamTask.Entity.Concrete.Identity;
using TeamTask.Shared.DTOs.Fill;
using TeamTask.Shared.DTOs.Task;
using TeamTask.Shared.DTOs.User;
using TeamTask.Shared.DTOs.WorkingSpace;

namespace TeamTask.Business.Mapping
{
  
    public class MappingProfileGeneral : Profile
    {
        public MappingProfileGeneral()
        {
           
            CreateMap<Entity.Concrete.TaskStatus, ChangeTaskStatusDTO>().ReverseMap();
            CreateMap<TaskUser, AssignUserToTaskDTO>().ReverseMap();
            CreateMap<Status, StatusDTO>().ReverseMap();
            CreateMap<UserNote, NoteDTO>().ReverseMap();    

          

        }
    }
}
