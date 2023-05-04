namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProgramDocumentBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Program, System.Guid, Document, System.Guid>
    {
        public System.Guid ProwId { get; set; }

        public System.Guid SternId { get; set; }

        public Program Prow { get; set; }

        public Document Stern { get; set; }
    }
}
