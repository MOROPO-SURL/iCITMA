namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class SceneryKindRepository:  Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.SceneryKind, System.Guid>
    {
        public SceneryKindRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
        
    }
}