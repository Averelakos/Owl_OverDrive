using AutoMapper;
using Owl.Overdrive.Business.DTOs.GameDtos.Create;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Business.MapperProfiles
{
    public partial class MapperProfile : Profile
    {
        public void MapGame()
        {
            CreateMap<CreateGameDto, Game>();
                //.ForMember(m => m.AlternativeGameTitles, opt => opt.MapFrom(m => m.AlternativeNames));
            CreateMap<CreateGameEditionDto, GameEdition>();
            CreateMap<CreativeAlternativeTitleDto, AlternativeGameTitle>();
        }
    }
}
