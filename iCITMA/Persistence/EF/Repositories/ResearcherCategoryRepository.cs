using Microsoft.EntityFrameworkCore;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class ResearcherCategoryRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<ResearcherCategory, System.Guid>
    {
        public ResearcherCategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
