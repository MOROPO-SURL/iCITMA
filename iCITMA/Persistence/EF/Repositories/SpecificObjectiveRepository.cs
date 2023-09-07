using Microsoft.EntityFrameworkCore;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class SpecificObjectiveRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.SpecificObjective, System.Guid>
    {
        public SpecificObjectiveRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<SpecificObjective> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(s => s.Project);
        }
    }
}
