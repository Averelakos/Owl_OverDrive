using Owl.Overdrive.Business.DTOs.CompanyDtos;
using Owl.Overdrive.Business.DTOs.PlatformDtos;
using Owl.Overdrive.Business.DTOs.ServiceResults;
using Owl.Overdrive.Domain.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Business.Contracts
{
    public interface IPlatformFacade
    {
        Task<List<SearchPlatformDto>> SearchPlatform(string? searchInput);
        Task<SearchPlatformDto?> GetPlatform(long input);
    }
}
