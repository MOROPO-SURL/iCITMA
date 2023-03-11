namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProjectCurrencyBudgetBridgeEntityTypeConfigurator : SAPRESSC.Core.Persistence.EF.Configurators.AbstractEntityTypeConfigurator<Entities.ProjectCurrencyBudgetBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.ProjectCurrencyBudgetBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.ProjectId, bridge.CurrencyId });

            entityTypeBuilder.HasOne(bridge => bridge.Project).WithMany(entity => entity.CurrencyBudgetBridges).HasForeignKey(bridge => bridge.ProjectId);
            entityTypeBuilder.HasOne(bridge => bridge.Currency).WithMany().HasForeignKey(bridge => bridge.CurrencyId);
        }
    }
}
