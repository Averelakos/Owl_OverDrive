using Owl.Overdrive.Business.DTOs.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Business.Contracts
{
    public interface ICompanyFacade
    {
        /// <summary>
        /// Creates the specified create company dto.
        /// </summary>
        /// <param name="createCompanyDto">The create company dto.</param>
        /// <returns></returns>
        Task Create(CreateCompanyDto createCompanyDto);
    }
}
