using Microsoft.EntityFrameworkCore;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class TeachingCategoryRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<TeachingCategory, System.Guid>
    {
        public TeachingCategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
