namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProjectPersonParticipationBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.ProjectPersonParticipationBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.ProjectPersonParticipationBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.ProjectId, bridge.PersonId });

            entityTypeBuilder.HasOne(bridge => bridge.Project).WithMany(entity => entity.PersonParticipationBridges).HasForeignKey(bridge => bridge.ProjectId);
            entityTypeBuilder.HasOne(bridge => bridge.Person).WithMany().HasForeignKey(bridge => bridge.PersonId);
        }
    }
}
