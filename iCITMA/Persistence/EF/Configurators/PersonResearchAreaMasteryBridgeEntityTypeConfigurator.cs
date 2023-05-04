using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class PersonResearchAreaMasteryBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<PersonResearchAreaMasteryBridge, Person, System.Guid, ResearchArea, System.Guid>
    {
        public PersonResearchAreaMasteryBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ResearchAreaMasteryBridges;
        }
    }
}
