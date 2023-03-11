namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class PersonInstitutionBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.PersonInstitutionBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.PersonInstitutionBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.PersonId, bridge.InstitutionId });

            entityTypeBuilder.HasOne(bridge => bridge.Person).WithMany(entity => entity.InstitutionBridges).HasForeignKey(bridge => bridge.PersonId);
            entityTypeBuilder.HasOne(bridge => bridge.Institution).WithMany().HasForeignKey(bridge => bridge.InstitutionId);
        }
    }
}
