using AutoMapper;
using Owl.Overdrive.Repository.Contracts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
namespace Owl.Overdrive.Business.Facades.Base
{
    /// <summary>
    /// The Base facade
    /// </summary>
    public class BaseFacade
    {
        protected readonly IRepositoryUnitOfWork _repoUoW;
        protected readonly IMapper _mapper;
        /// <summary>
        /// Initialize a new instance of the <see cref="BaseFacade"/> class.
        /// </summary>
        /// <param name="repoUoW"></param>
        public BaseFacade(IRepositoryUnitOfWork repoUoW, IMapper mapper)
        {
            _repoUoW = repoUoW;
            _mapper = mapper;
        }
    }
}
