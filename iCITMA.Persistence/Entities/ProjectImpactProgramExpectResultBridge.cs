namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProjectImpactProgramExpectResultBridge
    {
        public System.Guid ImapactId { get; set; }

        public System.Guid ExpectResultId { get; set; }

        public ProjectImpact Impact { get; set; }

        public ProgramExpectResult ExpectResult { get; set; } 
    }
}
