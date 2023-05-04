namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories
{
    public class ProjectStateRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.AbstractEntityRepository<Entities.ProjectState, System.Guid>
    {
        public ProjectStateRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }

        public override System.Func<Entities.ProjectState, object> GetPagingOrderSelector()
        {
            return entity => entity.Name;
        }
    }
}
