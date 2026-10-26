namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class FundingEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractEntityTypeConfigurator<Entities.Funding>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Funding> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasOne(entity => entity.Source).WithMany().HasForeignKey(entity => entity.SourceId).IsRequired();
        }
    }
}
