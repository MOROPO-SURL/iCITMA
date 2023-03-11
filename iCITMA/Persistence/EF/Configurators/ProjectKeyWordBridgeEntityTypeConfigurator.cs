namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProjectKeyWordBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.ProjectKeyWordBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.ProjectKeyWordBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.ProjectId, bridge.KeyWordId });

            entityTypeBuilder.HasOne(bridge => bridge.Project).WithMany(entity => entity.KeyWordBridges).HasForeignKey(bridge => bridge.ProjectId);
            entityTypeBuilder.HasOne(bridge => bridge.KeyWord).WithMany().HasForeignKey(bridge => bridge.KeyWordId);
        }
    }
}
