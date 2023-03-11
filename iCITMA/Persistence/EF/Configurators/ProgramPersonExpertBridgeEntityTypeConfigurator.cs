namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProgramPersonExpertBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.ProgramPersonExpertBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.ProgramPersonExpertBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.ProgramId, bridge.PersonId });

            entityTypeBuilder.HasOne(bridge => bridge.Program).WithMany(entity => entity.PersonExpertBridges).HasForeignKey(bridge => bridge.ProgramId);
            entityTypeBuilder.HasOne(bridge => bridge.Person).WithMany().HasForeignKey(bridge => bridge.PersonId);
        }
    }
}
