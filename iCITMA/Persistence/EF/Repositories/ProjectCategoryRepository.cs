using Microsoft.EntityFrameworkCore;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class ProjectCategoryRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<ProjectCategory, System.Guid>
    {
        public ProjectCategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
