using Microsoft.EntityFrameworkCore;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class FundingSourceRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<FundingSource, System.Guid>
    {
        public FundingSourceRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}