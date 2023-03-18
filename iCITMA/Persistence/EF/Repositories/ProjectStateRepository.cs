using Microsoft.EntityFrameworkCore;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class ProjectStateRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<ProjectState, System.Guid>
    {
        public ProjectStateRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<ProjectState, object> GetPagingOrderSelector()
        {
            return entity => entity.Name;
        }

        protected override System.Linq.IQueryable<ProjectState> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet();
        }
    }
}
