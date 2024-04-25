using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Entity.Concrete;
using TeamTask.Shared.DTOs.WorkingSpace;

namespace TeamTask.Business.Mapping
{
    public class MappingProfileWorkingSpaceComment:Profile
    {
        public MappingProfileWorkingSpaceComment()
        {
            CreateMap<WorkingSpaceComment, WorkingSpaceCommentDTO>()
          .ForMember(wscd => wscd.FullName, op => op.MapFrom(wsc => $"{wsc.User.FirstName} {wsc.User.LastName}"))
          .ForMember(wscd => wscd.CreatedDate, op => op.MapFrom(wsc => wsc.CreatedDate.ToString("dd/MM/yy HH:mm:ss"))).ReverseMap();

        }
    }
}
