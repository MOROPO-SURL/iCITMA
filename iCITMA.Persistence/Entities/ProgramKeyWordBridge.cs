namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProgramKeyWordBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Program, System.Guid, KeyWord, System.Guid>
    {
        public System.Guid ProwId { get; set; }

        public System.Guid SternId { get; set; }

        public Program Prow { get; set; }

        public KeyWord Stern { get; set; }
    }
}
