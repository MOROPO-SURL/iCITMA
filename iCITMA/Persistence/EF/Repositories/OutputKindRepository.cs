using Microsoft.EntityFrameworkCore;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class OutputKindRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<OutputKind, System.Guid>
    {
        public OutputKindRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}