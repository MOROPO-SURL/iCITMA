namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class KeyWordRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.KeyWord, System.Guid>
    {
        public KeyWordRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}

