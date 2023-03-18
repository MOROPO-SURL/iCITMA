using Microsoft.EntityFrameworkCore;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class ResearchAreaRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<ResearchArea, System.Guid>
    {
        public ResearchAreaRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<ResearchArea, object> GetPagingOrderSelector()
        {
            return entity => entity.Name;
        }

        protected override System.Linq.IQueryable<ResearchArea> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet();
        }
    }
}