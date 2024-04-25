using AutoMapper;
using TeamTask.Entity.Concrete;
using TeamTask.Entity.Concrete.Identity;
using TeamTask.Shared.AdminDTOs.User;
using TeamTask.Shared.DTOs.User;
using TeamTask.Shared.Types;

namespace TeamTask.Business.Mapping
{
    public class MappingProfileUser:Profile
    {
        public MappingProfileUser()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, A_UserDTO>().ReverseMap();
            CreateMap<User,UserForTaskAssignDTO>().ReverseMap();
            CreateMap<UserNote, UserNoteDTO>()
                .ForMember(utdo => utdo.PriorityColor, opt => opt.MapFrom(un =>  un.Priority.GetDescription()))
                .ForMember(utdo=> utdo.PriorityText, opt=> opt.MapFrom(un=>un.Priority == UserNotePriorityType.Low ? "Düşük" : un.Priority== UserNotePriorityType.Medium ? "Normal" : "Yüksek"))
                //.ForMember(utdo=>utdo.CreatedDate,opt=>opt.MapFrom(d=>d.CreatedDate.ToString("dd/MM/yy HH:mm:ss")))

                .ReverseMap();




        }
     
    }
}
