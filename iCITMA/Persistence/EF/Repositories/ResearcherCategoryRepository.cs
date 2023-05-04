namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class ResearcherCategoryRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.ResearcherCategory, System.Guid>
    {
        public ResearcherCategoryRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
