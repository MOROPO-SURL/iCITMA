using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProjectKeyWordBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<ProjectKeyWordBridge, Project, System.Guid, KeyWord, System.Guid>
    {
        public ProjectKeyWordBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.KeyWordBridges;
        }
    }
}
