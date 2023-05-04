namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class OutputKindRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.OutputKind, System.Guid>
    {
        public OutputKindRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}