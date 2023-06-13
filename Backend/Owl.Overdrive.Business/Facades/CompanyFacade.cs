using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.Facades.Base;
using Owl.Overdrive.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Business.Facades
{
    public class CompanyFacade : BaseFacade, ICompanyFacade
    {
        public CompanyFacade(IRepositoryUnitOfWork repoUoW) : base(repoUoW)
        {
        }
    }
}
