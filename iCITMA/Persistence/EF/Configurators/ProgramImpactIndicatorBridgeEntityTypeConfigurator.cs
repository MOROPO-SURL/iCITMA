namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProgramImpactIndicatorBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.ProgramImpactIndicatorBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.ProgramImpactIndicatorBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.ProgramId, bridge.ImpactIndicatorId });

            entityTypeBuilder.HasOne(bridge => bridge.Program).WithMany(entity => entity.ImpactIndicatorBridges).HasForeignKey(bridge => bridge.ProgramId);
            entityTypeBuilder.HasOne(bridge => bridge.ImpactIndicator).WithMany().HasForeignKey(bridge => bridge.ImpactIndicatorId);
        }
    }
}
