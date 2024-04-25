using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Shared.DTOs.Fill;
using TeamTask.Shared.DTOs.Task;

namespace TeamTask.Business.Mapping
{
    public class MappingProfileTask : Profile
    {
        public MappingProfileTask()
        {
            CreateMap<Entity.Concrete.Task, TaskDTO>().ReverseMap();
            CreateMap<Entity.Concrete.Task, UserTasksDTO>().ReverseMap();
            CreateMap<Entity.Concrete.Task, FillTaskDTO>().ReverseMap();
            CreateMap<Entity.Concrete.Task, CreateTaskDTO>().ReverseMap();
            CreateMap<Entity.Concrete.Task, UnDetailedTaskDTO>().ReverseMap();

            CreateMap<Entity.Concrete.Task, UnDetailedTaskDTO>()
           .ForMember(tdto => tdto.IsOver, op => op.MapFrom(t => t.EndDate < DateTime.Now))
           .ForMember(tdto => tdto.IsUserAssigned, op => op.MapFrom(u => u.TaskUsers.Count > 0 ? true : false))
           .ForMember(tdto => tdto.EndDate, op => op.MapFrom(t => t.EndDate.ToString("dd/MM/yy HH:mm:ss")))
          .ReverseMap();


            CreateMap<Entity.Concrete.Task, TaskDTO>()
             .ForMember(tdto => tdto.IsOver, op => op.MapFrom(t => t.EndDate < DateTime.Now))
             .ForMember(tdto=>tdto.IsUserAssigned, op=>op.MapFrom(u=>u.TaskUsers.Count>0? true: false))
             .ForMember(tdto => tdto.EndDate, op => op.MapFrom(t => t.EndDate.ToString("dd/MM/yy HH:mm:ss")))
             .ForMember(wsDTO => wsDTO.UserList,
               opt => opt.MapFrom(w => w.TaskUsers.Select(u => u.User)))
             .ForMember(wsDTO => wsDTO.Status,
               opt => opt  .MapFrom(w => w.TaskStatus.Status))
            .ReverseMap();


            CreateMap<Entity.Concrete.Task, UserTasksDTO>()
             .ForMember(utdto => utdto.SpaceComments, 
               opt => opt.MapFrom(t => t.WorkingSpaceTasks.FirstOrDefault().WorkingSpace.Comments.Take(1)))
             .ForMember(utdto => utdto.IsOver, op => op.MapFrom(t => t.EndDate < DateTime.Now))
             .ForMember(d => d.WorkingSpaceTitle, 
               opt => opt.MapFrom(wst => wst.WorkingSpaceTasks.FirstOrDefault().WorkingSpace.Title))
             .ForMember(wsDTO => wsDTO.Status,
               opt => opt .MapFrom(w => w.TaskStatus.Status))
            .ReverseMap();
        }
    }
}
