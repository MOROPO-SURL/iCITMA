namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProjectProgramExpectResultBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Project, System.Guid, ProgramExpectResult, System.Guid>
    {
        public System.Guid ProwId { get; set; }

        public System.Guid SternId { get; set; }

        public Project Prow { get; set; }

        public ProgramExpectResult Stern { get; set; }
    }
}
