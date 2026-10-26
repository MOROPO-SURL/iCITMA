using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class PersonResearchAreaDoctorateBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<PersonResearchAreaDoctorateBridge, Person, System.Guid, ResearchArea, System.Guid>
    {
        public PersonResearchAreaDoctorateBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ResearchAreaDoctorateBridges;
        }
    }
}
