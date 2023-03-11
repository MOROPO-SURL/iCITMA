namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class PersonResearchAreaDoctorateBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.PersonResearchAreaDoctorateBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.PersonResearchAreaDoctorateBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.PersonId, bridge.ResearchAreaId });

            entityTypeBuilder.HasOne(bridge => bridge.Person).WithMany(entity => entity.ResearchAreaDoctorateBridges).HasForeignKey(bridge => bridge.PersonId);
            entityTypeBuilder.HasOne(bridge => bridge.ResearchArea).WithMany().HasForeignKey(bridge => bridge.ResearchAreaId);
        }
    }
}
