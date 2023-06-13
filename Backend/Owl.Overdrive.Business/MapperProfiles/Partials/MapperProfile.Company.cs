using AutoMapper;
using Owl.Overdrive.Business.DTOs.CompanyDtos;
using Owl.Overdrive.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Business.MapperProfiles
{
    public partial class MapperProfile : Profile
    {
        public void MapCompany()
        {
            CreateMap<CreateCompanyDto, Company>();
        }
    }
}
