namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class ResearchAreaRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.ResearchArea, System.Guid>
    {
        public ResearchAreaRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<Entities.ResearchArea, object> GetPagingOrderSelector()
        {
            return entity => entity.Name;
        }
    }
}