using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProjectImpactProgramExpectResultBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<ProjectImpactProgramExpectResultBridge, ProjectImpact, System.Guid, ProgramExpectResult, System.Guid>
    {
        public ProjectImpactProgramExpectResultBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ProgramExpectResultBridges;
        }
    }
}
