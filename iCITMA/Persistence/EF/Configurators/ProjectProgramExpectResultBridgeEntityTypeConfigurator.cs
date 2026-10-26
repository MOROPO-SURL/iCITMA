using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProjectProgramExpectResultBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<ProjectProgramExpectResultBridge, Project, System.Guid, ProgramExpectResult, System.Guid>
    {
        public ProjectProgramExpectResultBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ProgramExpectResultBridges;
        }
    }
}
