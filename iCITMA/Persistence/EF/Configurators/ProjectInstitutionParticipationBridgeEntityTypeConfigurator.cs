namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProjectInstitutionParticipationBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.ProjectInstitutionParticipationBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.ProjectInstitutionParticipationBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.ProjectId, bridge.InstitutionId });

            entityTypeBuilder.HasOne(bridge => bridge.Project).WithMany(entity => entity.InstitutionParticipationBridges).HasForeignKey(bridge => bridge.ProjectId);
            entityTypeBuilder.HasOne(bridge => bridge.Institution).WithMany().HasForeignKey(bridge => bridge.InstitutionId);
        }
    }
}
