using Microsoft.EntityFrameworkCore;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class ProgramExpectResultRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.ProgramExpectResult, System.Guid>
    {
        public ProgramExpectResultRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.ProgramExpectResult> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.Program);
        }
    }
}
