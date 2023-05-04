namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class ProgramCategoryRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.ProgramCategory, System.Guid>
    {
        public ProgramCategoryRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}