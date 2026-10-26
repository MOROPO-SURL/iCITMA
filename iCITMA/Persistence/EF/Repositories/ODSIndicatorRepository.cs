using Microsoft.EntityFrameworkCore;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class ODSIndicatorRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.ODSIndicator, System.Guid>
    {
        public ODSIndicatorRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
