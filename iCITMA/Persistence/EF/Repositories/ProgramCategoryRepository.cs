using Microsoft.EntityFrameworkCore;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class ProgramCategoryRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<ProgramCategory, System.Guid>
    {
        public ProgramCategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}