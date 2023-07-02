using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.CompanyDtos;
using Owl.Overdrive.Business.Facades.Base;
using Owl.Overdrive.Domain.Entities.Company;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Business.Facades
{
    public class CompanyFacade : BaseFacade, ICompanyFacade
    {
        public CompanyFacade(IRepositoryUnitOfWork repoUoW, IMapper mapper) : base(repoUoW, mapper)
        {
        }

        public async Task Create(CreateCompanyDto createCompanyDto)
        {
            try
            {
                var company = _mapper.Map<Company>(createCompanyDto);

                //TODO: set createby and lastupdateby
                var result = await _repoUoW.CompanyRepository.Insert(company);
                var imageResult = await _repoUoW.ImageDraftRepository.GetImageByGuid(createCompanyDto.imageGuid);

                if (imageResult != null)
                {
                    CompanyLogo logo = new CompanyLogo()
                    {
                        CompanyId = company.Id,
                        ImageTitle = imageResult.ImageTitle,
                        ImageData = imageResult.ImageData,
                    };

                    await _repoUoW.CompanyLogoRepository.Insert(logo);
                }
            }
            catch (Exception ex)
            {
                // logger and responce message
            }
            
        }

        public async Task<List<SearchParentCompanyDto>> Search(string searchInput)
        {
            List<SearchParentCompanyDto> result = new List<SearchParentCompanyDto>();
            if(!string.IsNullOrWhiteSpace(searchInput) && searchInput.Length > 2)
            {
               var list = await _repoUoW.CompanyRepository.Search(searchInput);
               result = _mapper.Map<List<SearchParentCompanyDto>>(list);
            }

            return result;
        }

        public async Task<List<ListCompanyDto>> GetAll()
        {
            return _mapper.Map<List<ListCompanyDto>>(await _repoUoW.CompanyRepository.GetList());
        }

        public async Task<SimpleCompanyDto> GetCompanyById(long companyId)
        {
            var result =  _mapper.Map<SimpleCompanyDto>( await _repoUoW.CompanyRepository.GetCompanyById(companyId));

            var logoResult = await _repoUoW.CompanyLogoRepository.GetCompanyLogo(companyId);
            if (logoResult is not null) 
            {
                result.ImageTitle = logoResult.ImageTitle;
                result.ImageData = logoResult.ImageData;
            }

            return result;
        }
    }
}
