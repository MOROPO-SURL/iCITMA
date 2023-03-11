namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class PersonResearchAreaSpecializationBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.PersonResearchAreaSpecializationBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.PersonResearchAreaSpecializationBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.PersonId, bridge.ResearchAreaId });

            entityTypeBuilder.HasOne(bridge => bridge.Person).WithMany(entity => entity.ResearchAreaSpecializationBridges).HasForeignKey(bridge => bridge.PersonId);
            entityTypeBuilder.HasOne(bridge => bridge.ResearchArea).WithMany().HasForeignKey(bridge => bridge.ResearchAreaId);
        }
    }
}
