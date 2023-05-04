namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class ImpactIndicatorRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.ImpactIndicator, System.Guid>
    {
        public ImpactIndicatorRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<Entities.ImpactIndicator, object> GetPagingOrderSelector()
        {
            return entity => entity.Name;
        }
    }
}
