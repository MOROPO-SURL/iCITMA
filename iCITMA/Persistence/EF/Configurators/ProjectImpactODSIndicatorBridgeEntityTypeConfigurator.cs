namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProjectImpactODSIndicatorBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.ProjectImpactODSIndicatorBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.ProjectImpactODSIndicatorBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.ImapactId, bridge.IndicatorId });

            entityTypeBuilder.HasOne(bridge => bridge.Impact).WithMany(entity => entity.ODSIndicatorBridges).HasForeignKey(bridge => bridge.ImapactId);
            entityTypeBuilder.HasOne(bridge => bridge.Indicator).WithMany().HasForeignKey(bridge => bridge.IndicatorId);
        }
    }
}
