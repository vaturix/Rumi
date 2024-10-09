using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Terminology.EntityFrameworkCore;

namespace Terminology.Terms
{
    public class EfCoreTermRepository : EfCoreTermRepositoryBase, ITermRepository
    {
        public EfCoreTermRepository(IDbContextProvider<TerminologyDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}