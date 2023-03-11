namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProgramKeyWordBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.ProgramKeyWordBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.ProgramKeyWordBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.ProgramId, bridge.KeyWordId });

            entityTypeBuilder.HasOne(bridge => bridge.Program).WithMany(entity => entity.KeyWordBridges).HasForeignKey(bridge => bridge.ProgramId);
            entityTypeBuilder.HasOne(bridge => bridge.KeyWord).WithMany().HasForeignKey(bridge => bridge.KeyWordId);
        }
    }
}
