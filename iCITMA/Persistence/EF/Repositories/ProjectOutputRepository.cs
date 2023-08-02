using Microsoft.EntityFrameworkCore;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class ProjectOutputRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.ProjectOutput, System.Guid>
    {
        public ProjectOutputRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.ProjectOutput> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.Kind);
        }
    }
}
