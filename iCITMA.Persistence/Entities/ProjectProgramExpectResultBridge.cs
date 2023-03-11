namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProjectProgramExpectResultBridge
    {
        public System.Guid ProjectId { get; set; }

        public System.Guid ExpectResultId { get; set; }

        public Project Project { get; set; }

        public ProgramExpectResult ExpectResult { get; set; }
    }
}
