using Microsoft.EntityFrameworkCore;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class ProjectRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.Project, System.Guid>
    {
        public ProjectRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Project> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.State).Include(entity => entity.Program)
                .Include(entity => entity.Category).Include(entity => entity.Manager).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.Leader).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.ProgramExpectResultBridges).ThenInclude(entity => entity.Stern);
        }
    }
}
