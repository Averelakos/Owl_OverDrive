using Owl.Overdrive.Business.DTOs.LookupsDtos;

namespace Owl.Overdrive.Business.Contracts
{
    public interface ILookupFacade
    {
        Task<LookupsDto> Get();
    }
}
