namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class PersonEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.Person>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Person> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasOne(entity => entity.Identity).WithOne().HasForeignKey<Entities.Person>(entity => entity.IdentityId).IsRequired();
        }
    }
}
