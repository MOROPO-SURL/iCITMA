using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProjectInstitutionClientBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<ProjectInstitutionClientBridge, Project, System.Guid, Institution, System.Guid>
    {
        public ProjectInstitutionClientBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.InstitutionClientBridges;
        }
    }
}
