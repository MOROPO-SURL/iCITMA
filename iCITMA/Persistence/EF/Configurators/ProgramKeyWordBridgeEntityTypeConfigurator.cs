using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Configurators
{
    public class ProgramKeyWordBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractBridgeEntityTypeConfigurator<ProgramKeyWordBridge, Entities.Program, System.Guid, KeyWord, System.Guid>
    {
        public ProgramKeyWordBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.KeyWordBridges;
        }
    }
}
