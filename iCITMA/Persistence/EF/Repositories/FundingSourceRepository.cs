namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class FundingSourceRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.FundingSource, System.Guid>
    {
        public FundingSourceRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}