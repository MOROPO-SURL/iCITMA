using Microsoft.EntityFrameworkCore;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class SceneryKindRepository:  SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<SceneryKind, System.Guid>
    {
        public SceneryKindRepository(DbContext dbContext) : base(dbContext)
        {
        }
        
    }
}