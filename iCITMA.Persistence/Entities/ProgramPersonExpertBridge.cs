namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProgramPersonExpertBridge
    {
        public System.Guid ProgramId { get; set; }

        public System.Guid PersonId { get; set; }

        public Program Program { get; set; }

        public Person Person { get; set; }
    }
}
