using Microsoft.EntityFrameworkCore;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class ProjectImpactRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<ProjectImpact, System.Guid>
    {
        public ProjectImpactRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<ProjectImpact> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.Indicator)
                .Include(entity => entity.Project)
                .Include(entity => entity.ProgramExpectResultBridges).ThenInclude(entity => entity.Stern)
                .Include(entity => entity.ODSIndicatorBridges).ThenInclude(entity => entity.Stern);
        }
    }
}
