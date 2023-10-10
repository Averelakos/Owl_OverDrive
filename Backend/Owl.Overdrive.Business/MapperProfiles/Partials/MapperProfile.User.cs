using AutoMapper;
using Owl.Overdrive.Business.DTOs.User.Display;
using Owl.Overdrive.Domain.Entities.Auth;

namespace Owl.Overdrive.Business.MapperProfiles
{
    public partial class MapperProfile : Profile
    {
        public void MapUser()
        {
            CreateMap<User, UserSimpleDto>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(m => m.Roles[0].RoleId));
            CreateMap<UserSimpleDto, User>();
                //.//ForPath(dest => dest.Roles[0].RoleId, opt => opt.MapFrom(m => m.RoleId));
        }
    }
}
