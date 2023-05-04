using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProjectPersonParticipationBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<ProjectPersonParticipationBridge, Project, System.Guid, Person, System.Guid>
    {
        public ProjectPersonParticipationBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.PersonParticipationBridges;
        }
    }
}
