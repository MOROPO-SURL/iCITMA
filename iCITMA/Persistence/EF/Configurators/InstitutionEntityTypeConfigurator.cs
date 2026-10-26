namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class InstitutionEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractEntityTypeConfigurator<Entities.Institution>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Institution> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasOne(entity => entity.Identity).WithOne().HasForeignKey<Entities.Institution>(entity => entity.IdentityId).IsRequired();
        }
    }
}
