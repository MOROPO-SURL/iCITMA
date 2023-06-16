using Microsoft.EntityFrameworkCore;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.Framework.Guama.Location.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class InstitutionRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.Institution, System.Guid>
    {
        public InstitutionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Institution> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Identity.PhoneContactItemBridges).ThenInclude(entity => entity.Stern)
                .Include(entity => entity.Identity.EmailContactItemBridges).ThenInclude(entity => entity.Stern)
                .Include(entity => entity.Identity.SocialContactItemBridges).ThenInclude(entity => entity.Stern)
                .Include(entity => entity.Identity.WebSiteContactItemBridges).ThenInclude(entity => entity.Stern)
                .Include(entity => entity.Identity.PostalContactItemBridges).ThenInclude(entity => entity.Stern)
                .ThenInclude(entity => entity.Location).ThenInclude(entity => ((MunicipalityLocation)entity).Municipality)
                .ThenInclude(entity => entity.State)
                .Include(entity => entity.Representative).ThenInclude(entity => entity.Identity);            
        }
    }
}
