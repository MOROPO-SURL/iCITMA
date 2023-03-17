using Microsoft.EntityFrameworkCore;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class ImpactIndicatorRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<ImpactIndicator, System.Guid>
    {
        public ImpactIndicatorRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<ImpactIndicator, object> GetPagingOrderSelector()
        {
            return entity => entity.Name;
        }

        protected override System.Linq.IQueryable<ImpactIndicator> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet();
        }
    }
}
