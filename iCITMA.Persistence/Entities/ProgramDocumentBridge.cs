namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProgramDocumentBridge
    {
        public System.Guid ProgramId { get; set; }

        public System.Guid DocumentId { get; set; }

        public Program Program { get; set; }

        public Document Document { get; set; }
    }
}
