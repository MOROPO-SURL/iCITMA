namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProjectEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractEntityTypeConfigurator<Entities.Project>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Project> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasOne(entity => entity.State).WithMany().HasForeignKey(entity => entity.StateId).IsRequired();
        }
    }
}
