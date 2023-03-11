namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProgramDocumentBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.ProgramDocumentBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.ProgramDocumentBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.ProgramId, bridge.DocumentId });

            entityTypeBuilder.HasOne(bridge => bridge.Program).WithMany(entity => entity.DocumentBridges).HasForeignKey(bridge => bridge.ProgramId);
            entityTypeBuilder.HasOne(bridge => bridge.Document).WithMany().HasForeignKey(bridge => bridge.DocumentId);
        }
    }
}
