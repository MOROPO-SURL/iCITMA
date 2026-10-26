using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProgramImpactIndicatorBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<ProgramImpactIndicatorBridge, Entities.Program, System.Guid, ImpactIndicator, System.Guid>
    {
        public ProgramImpactIndicatorBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ImpactIndicatorBridges;
        }
    }
}
