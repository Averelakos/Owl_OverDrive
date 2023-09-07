using AutoMapper;
using Owl.Overdrive.Business.DTOs.LookupsDtos;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Domain.Entities.Company;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Business.MapperProfiles
{
    public partial class MapperProfile: Profile
    {
        public void MapLookups()
        {
            CreateMap<CompanyStatus, CompanyStatusLookupDto>();
            CreateMap<CountryCode, CountryCodeLookupDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.CountryName));
            CreateMap<Region, RegionLookupDto>();
            CreateMap<Language, LanguageLookupDto>();
        }
    }
}
