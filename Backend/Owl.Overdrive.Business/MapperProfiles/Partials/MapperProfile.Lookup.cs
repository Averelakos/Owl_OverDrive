using AutoMapper;
using Owl.Overdrive.Business.DTOs.LookupsDtos;
using Owl.Overdrive.Domain.Entities;

namespace Owl.Overdrive.Business.MapperProfiles
{
    public partial class MapperProfile: Profile
    {
        public MapperProfile() 
        {
            CreateMap<CompanyStatus, CompanyStatusLookupDto>();
            CreateMap<CountryCode, CountryCodeLookupDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.CountryName));
        }
    }
}
