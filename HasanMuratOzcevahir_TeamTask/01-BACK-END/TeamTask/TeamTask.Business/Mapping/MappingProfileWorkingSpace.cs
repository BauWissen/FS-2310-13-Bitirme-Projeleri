using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Entity.Concrete;
using TeamTask.Shared.DTOs.Fill;
using TeamTask.Shared.DTOs.WorkingSpace;

namespace TeamTask.Business.Mapping
{
    public class MappingProfileWorkingSpace : Profile
    {
        public MappingProfileWorkingSpace()
        {
            CreateMap<WorkingSpace, CreateWorkingSpaceDTO>().ReverseMap();
            CreateMap<WorkingSpace, WorkingSpaceDTO>().ReverseMap();
            CreateMap<WorkingSpace, FillWorkingSpaceDTO>().ReverseMap();
            CreateMap<WorkingSpace, WorkingSpaceInTaskDTO>().ReverseMap();

            CreateMap<WorkingSpace, WorkingSpaceDTO>()
            .ForMember(wsDTO => wsDTO.TaskList, opt =>
              opt.MapFrom(w => w.WorkingSpaceTasks.Select(t => t.Task))
                )
            //.ForMember(wsdTO => wsdTO.OwnerId,
            //  opt => opt.MapFrom(ws => ws.UserId)) no need for now
            .ReverseMap();

            CreateMap<WorkingSpace, WorkingSpaceDetailDTO>()
              .ForMember(wsDTO => wsDTO.TaskList, opt =>
                opt.MapFrom(w => w.WorkingSpaceTasks.Select(t => t.Task))
                  )
              .ForMember(wsDTO => wsDTO.TaskCount,
                opt => opt.MapFrom(t => t.WorkingSpaceTasks.Count))
              .ForMember(wsDTO => wsDTO.CommentCount,
                opt => opt.MapFrom(c => c.Comments.Count))
              .ForMember(wsdTO => wsdTO.OwnerId,
                opt => opt.MapFrom(ws => ws.UserId))
              .ForMember(wsc => wsc.Comments,
                opt => opt.MapFrom(c => c.Comments))
              .ReverseMap();
        }
    }
}
