using Microsoft.EntityFrameworkCore;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class PersonRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.Person, System.Guid>
    {
        public PersonRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<Entities.Person, object> GetPagingOrderSelector()
        {
            return entity => entity.Identity.Name;
        }

        protected override System.Linq.IQueryable<Entities.Person> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Identity.PhoneContactItemBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.Identity.EmailContactItemBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.Identity.WebSiteContactItemBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.Identity.PostalContactItemBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Location).ThenInclude(entity => ((Framework.Guama.Location.Persistence.Entities.MunicipalityLocation)entity).Municipality).ThenInclude(entity => entity.State)
                .Include(entity => entity.ResearcherCategory)
                .Include(entity => entity.TeachingCategory)
                .Include(entity => entity.ResearchAreaSpecializationBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.ResearchAreaMasteryBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.ResearchAreaDoctorateBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.InstitutionBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}
