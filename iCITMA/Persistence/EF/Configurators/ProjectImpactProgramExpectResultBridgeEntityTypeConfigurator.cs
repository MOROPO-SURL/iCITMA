namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProjectImpactProgramExpectResultBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.ProjectImpactProgramExpectResultBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.ProjectImpactProgramExpectResultBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.ImapactId, bridge.ExpectResultId });

            entityTypeBuilder.HasOne(bridge => bridge.Impact).WithMany(entity => entity.ProgramExpectResultBridges).HasForeignKey(bridge => bridge.ImapactId);
            entityTypeBuilder.HasOne(bridge => bridge.ExpectResult).WithMany().HasForeignKey(bridge => bridge.ExpectResultId);
        }
    }
}
