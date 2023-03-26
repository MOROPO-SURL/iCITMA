using Microsoft.EntityFrameworkCore;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class KeyWordRepository : SAPRESSC.Core.Persistence.EF.Repositories.AbstractEntityRepository<KeyWord, System.Guid>
    {
        public KeyWordRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}

