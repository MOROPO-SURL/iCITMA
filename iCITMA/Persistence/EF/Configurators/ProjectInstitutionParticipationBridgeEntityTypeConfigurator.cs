using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProjectInstitutionParticipationBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<ProjectInstitutionParticipationBridge, Project, System.Guid, Institution, System.Guid>
    {
        public ProjectInstitutionParticipationBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.InstitutionParticipationBridges;
        }
    }
}
