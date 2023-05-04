using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProgramInstitutionResponsibleBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<ProgramInstitutionResponsibleBridge, Entities.Program, System.Guid, Institution, System.Guid>
    {
        public ProgramInstitutionResponsibleBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.InstitutionResponsibleBridges;
        }
    }
}
