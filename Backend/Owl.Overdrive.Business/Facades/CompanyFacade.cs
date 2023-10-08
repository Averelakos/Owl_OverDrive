using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.CompanyDtos;
using Owl.Overdrive.Business.DTOs.CompanyDtos.Create;
using Owl.Overdrive.Business.DTOs.CompanyDtos.Display;
using Owl.Overdrive.Business.DTOs.CompanyDtos.Update;
using Owl.Overdrive.Business.DTOs.GameDtos.Display.Simple;
using Owl.Overdrive.Business.DTOs.ServiceResults;
using Owl.Overdrive.Business.Facades.Base;
using Owl.Overdrive.Business.Services;
using Owl.Overdrive.Business.Services.Models;
using Owl.Overdrive.Domain.Entities.Company;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Business.Facades
{
    public class CompanyFacade : BaseFacade, ICompanyFacade
    {
        public CompanyFacade(IRepositoryUnitOfWork repoUoW, IMapper mapper) : base(repoUoW, mapper)
        {
        }

        private IQueryable<T> List<T>()
        {
            return _repoUoW.CompanyRepository
                    .QueryCompany()
                    .AsNoTracking()
                    .ProjectTo<T>(_mapper.ConfigurationProvider);
        }

        #region Create
        public async Task<ServiceResult<CreateCompanyDto>> Create(CreateCompanyDto createCompanyDto)
        {
            ServiceResult<CreateCompanyDto> response = new ();
            response.Result = createCompanyDto;
            try
            {
                var company = _mapper.Map<Company>(createCompanyDto);

                //TODO: set createby and lastupdateby
                var imageResult = await _repoUoW.ImageDraftRepository.GetImageByGuid(createCompanyDto.imageGuid);

                if (imageResult != null)
                {
                    CompanyLogo logo = new CompanyLogo()
                    {

                        ImageTitle = imageResult.ImageTitle,
                        ImageData = imageResult.ImageData,
                    };

                    var newCompanylogo = await _repoUoW.CompanyLogoRepository.Insert(logo);

                    if (newCompanylogo != null)
                    {
                        company.CompanyLogoId = newCompanylogo.Id;
                    }

                    await _repoUoW.ImageDraftRepository.DeleteImageDraft(createCompanyDto.imageGuid);
                }
                
                var result = await _repoUoW.CompanyRepository.Insert(company);
                response.Result.Id = result.Id;

                return response;
            }
            catch (Exception ex)
            {
                // logger and responce message
                response.Success = false;
                response.Error = ex.Message;
                return response;
            }
            
        }
        #endregion Creeate

        #region Display
        public async Task<ServiceSearchResultData<List<CompanySimpleDto>>> ListCompany(DataLoaderOptions options)
        {
            IQueryable<CompanySimpleDto> source = List<CompanySimpleDto>();

            var dataDesult = await new DataLoaderService<CompanySimpleDto>(source, options).LoadResult();

            ServiceSearchResultData<List<CompanySimpleDto>> result = new();

            if (dataDesult.Data is not null)
            {
                result.Result = dataDesult.Data.ToList();
                result.TotalCount = dataDesult.TotalCount;
                result.TotalPages = dataDesult.TotalPages;
                return result;
            }
            else
            {
                result.Result = new List<CompanySimpleDto>();
                return result;
            }
        }
        #endregion Display

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

        public async Task<SearchParentCompanyDto> RetrieveSearchValue(long searchInput)
        {
            var result = _mapper.Map<SearchParentCompanyDto>(await _repoUoW.CompanyRepository.GetCompanyById(searchInput));

            return result;
        }

        public async Task<SimpleCompanyDto> GetCompanyById(long companyId)
        {
            var result =  _mapper.Map<SimpleCompanyDto>( await _repoUoW.CompanyRepository.GetCompanyById(companyId));

            var logoResult = await _repoUoW.CompanyLogoRepository.GetCompanyLogo(result.CompanyLogoId);
            if (logoResult is not null)
            {
                result.ImageTitle = logoResult.ImageTitle;
                result.ImageData = logoResult.ImageData;
            }

            return result;
        }

        public async Task<UpdateCompanyDto> GetCompanyForUpdate(long companyId)
        {
            var result = _mapper.Map<UpdateCompanyDto>(await _repoUoW.CompanyRepository.GetCompanyById(companyId));
            return result;
        }

        public async Task<UpdateCompanyLogoDto> GetLogoByCompanyId(long companyId)
        {
            var result = _mapper.Map<UpdateCompanyLogoDto>(await _repoUoW.CompanyLogoRepository.GetById(companyId));
            return result;
        }

        public async Task<ServiceResult<UpdateCompanyDto>> UpdateCompany(UpdateCompanyDto updateCompanyDto)
        {
            ServiceResult<UpdateCompanyDto> response = new()
            {
                Result = updateCompanyDto
            };

            await _repoUoW.CompanyRepository.BeginTransactionAsync();
            try
            {
                var company = await _repoUoW.CompanyRepository.GetById(updateCompanyDto.Id);
                
                if (company is null)
                {
                    throw new Exception();
                }

                _mapper.Map<UpdateCompanyDto, Company>(updateCompanyDto, company);


                if (updateCompanyDto.CompanyLogoId.HasValue)
                {
                    // TODO do not know yet
                }
                else if (updateCompanyDto.NewCompanyLogoId.HasValue)
                {
                    var imageResult = await _repoUoW.ImageDraftRepository.GetImageByGuid(updateCompanyDto.NewCompanyLogoId);
                    if (imageResult != null)
                    {
                        CompanyLogo logo = new CompanyLogo()
                        {
                            //CompanyId = company.Id,
                            ImageTitle = imageResult.ImageTitle,
                            ImageData = imageResult.ImageData,
                        };

                       var newCompanyLogo =  await _repoUoW.CompanyLogoRepository.Insert(logo);
                       await _repoUoW.ImageDraftRepository.DeleteImageDraft(updateCompanyDto.NewCompanyLogoId);

                        if (newCompanyLogo is null) 
                        {
                            throw new ArgumentNullException(nameof(newCompanyLogo));
                        }

                        company.CompanyLogoId = newCompanyLogo.Id;

                    }
                }
                // TODO: REMOVE IMAGE

                await _repoUoW.CompanyRepository.UpdateCompany(company);
                await _repoUoW.CompanyRepository.CommitTransactionAsync();
                //TODO: RETURN SUCCESS RESPONSE
                return response;
            }
            catch (Exception ex)
            {
                await _repoUoW.CompanyRepository.RollBackTransactionAsync();
                //TODO: RETURN ERROR RESPONSE
                response.Success = false;
                response.Error = ex.Message;
                return response;
            }
        }
    }
}
