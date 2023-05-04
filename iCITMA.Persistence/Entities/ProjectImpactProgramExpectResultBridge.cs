namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProjectImpactProgramExpectResultBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<ProjectImpact, System.Guid, ProgramExpectResult, System.Guid>
    {
        public System.Guid ProwId { get; set; }

        public System.Guid SternId { get; set; }

        public ProjectImpact Prow { get; set; }

        public ProgramExpectResult Stern { get; set; } 
    }
}
