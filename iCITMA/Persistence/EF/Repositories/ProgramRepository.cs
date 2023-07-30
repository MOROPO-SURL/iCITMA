using Microsoft.EntityFrameworkCore;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class ProgramRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.Program, System.Guid>
    {
        public ProgramRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Program> GetQueryableDbSet() 
        {
            return base.GetQueryableDbSet().Include(entity => entity.Category)
                .Include(entity => entity.Manager).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.Leader).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.PersonExpertBridges).ThenInclude(entity => entity.Stern)
                .Include(entity => entity.KeyWordBridges).ThenInclude(entity => entity.Stern)
                .Include(entity => entity.DocumentBridges).ThenInclude(entity => entity.Stern);
        }
    }
}
