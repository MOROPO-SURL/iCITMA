using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProjectImpactODSIndicatorBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<ProjectImpactODSIndicatorBridge, ProjectImpact, System.Guid, ODSIndicator, System.Guid>
    {
        public ProjectImpactODSIndicatorBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ODSIndicatorBridges;
        }
    }
}
