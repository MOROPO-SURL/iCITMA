using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class PersonInstitutionBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<PersonInstitutionBridge, Person, System.Guid, Institution, System.Guid>
    {
        public PersonInstitutionBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.InstitutionBridges;
        }
    }
}
