using Owl.Overdrive.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Business.Facades.Base
{
    /// <summary>
    /// The Base facade
    /// </summary>
    public class BaseFacade
    {
        private readonly IRepositoryUnitOfWork _repoUoW;
        /// <summary>
        /// Initialize a new instance of the <see cref="BaseFacade"/> class.
        /// </summary>
        /// <param name="repoUoW"></param>
        public BaseFacade(IRepositoryUnitOfWork repoUoW)
        {
            _repoUoW = repoUoW;
        }
    }
}
