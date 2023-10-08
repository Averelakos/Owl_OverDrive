using AutoMapper;
using Owl.Overdrive.Business.DTOs.CompanyDtos;
using Owl.Overdrive.Business.DTOs.CompanyDtos.Create;
using Owl.Overdrive.Business.DTOs.CompanyDtos.Display;
using Owl.Overdrive.Business.DTOs.CompanyDtos.Update;
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
            CreateMap<Company, SimpleCompanyDto>()
                .ForMember(x => x.ParentCompanyName, opt => opt.MapFrom(x => x.Name));
            CreateMap<Company, UpdateCompanyDto>();
            CreateMap<CompanyLogo, UpdateCompanyLogoDto>();
            CreateMap<UpdateCompanyDto, Company>();
            CreateMap<Company, CompanySimpleDto>();
        }
    }
}
