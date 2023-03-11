namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProgramInstitutionResponsibleBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.ProgramInstitutionResponsibleBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.ProgramInstitutionResponsibleBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.ProgramId, bridge.InstitutionId });

            entityTypeBuilder.HasOne(bridge => bridge.Program).WithMany(entity => entity.InstitutionResponsibleBridges).HasForeignKey(bridge => bridge.ProgramId);
            entityTypeBuilder.HasOne(bridge => bridge.Institution).WithMany().HasForeignKey(bridge => bridge.InstitutionId);
        }
    }
}
