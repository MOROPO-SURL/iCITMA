namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class TeachingCategoryRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.TeachingCategory, System.Guid>
    {
        public TeachingCategoryRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
