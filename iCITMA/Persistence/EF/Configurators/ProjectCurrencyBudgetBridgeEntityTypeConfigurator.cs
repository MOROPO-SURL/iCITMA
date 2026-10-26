using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProjectCurrencyBudgetBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<ProjectCurrencyBudgetBridge, Project, System.Guid, Currency, int>
    {
        public ProjectCurrencyBudgetBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.CurrencyBudgetBridges;
        }
    }
}
