using Microsoft.EntityFrameworkCore;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class DocumentRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.Document, System.Guid>
    {
        public DocumentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
