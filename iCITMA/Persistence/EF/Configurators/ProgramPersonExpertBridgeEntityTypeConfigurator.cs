using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProgramPersonExpertBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<ProgramPersonExpertBridge, Entities.Program, System.Guid, Person, System.Guid>
    {
        public ProgramPersonExpertBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.PersonExpertBridges;
        }
    }
}
