using AutoMapper;
using Owl.Overdrive.Business.DTOs.LookupsDtos;
using Owl.Overdrive.Business.DTOs.PlatformDtos;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Domain.Entities.Company;

namespace Owl.Overdrive.Business.MapperProfiles
{
    public partial class MapperProfile: Profile
    {
        public void MapPlatforms()
        {
            CreateMap<Platform, SearchPlatformDto>();
        }
    }
}
