using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class PersonResearchAreaSpecializationBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<PersonResearchAreaSpecializationBridge, Person, System.Guid, ResearchArea, System.Guid>
    {
        public PersonResearchAreaSpecializationBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ResearchAreaSpecializationBridges;
        }
    }
}
