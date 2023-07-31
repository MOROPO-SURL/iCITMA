using Microsoft.EntityFrameworkCore;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class PersonRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.Person, System.Guid>
    {
        public PersonRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<Entities.Person, object> GetPagingOrderSelector()
        {
            return entity => entity.Identity.Name;
        }

        protected override System.Linq.IQueryable<Entities.Person> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(p => p.Identity).ThenInclude(p => p.Image)
                .Include(p => p.ResearcherCategory)
                .Include(p => p.TeachingCategory)
                .Include(p => p.ResearchAreaSpecializationBridges).ThenInclude(p => p.Stern)
                .Include(p => p.ResearchAreaMasteryBridges).ThenInclude(p => p.Stern)
                .Include(p => p.ResearchAreaDoctorateBridges).ThenInclude(p => p.Stern)
                .Include(p => p.InstitutionBridges).ThenInclude(p => p.Stern);
        }
    }
}
