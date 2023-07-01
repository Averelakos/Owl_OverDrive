using AutoMapper;
using Owl.Overdrive.Business.DTOs.CompanyDtos;
using Owl.Overdrive.Domain.Entities.Company;

namespace Owl.Overdrive.Business.MapperProfiles
{
    public partial class MapperProfile : Profile
    {
        public void MapCompany()
        {
            CreateMap<CreateCompanyDto, Company>();
            CreateMap<Company, SearchParentCompanyDto>();
            CreateMap<Company, ListCompanyDto>();
        }
    }
}
