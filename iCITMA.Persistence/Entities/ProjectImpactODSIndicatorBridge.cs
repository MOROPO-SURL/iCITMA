namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProjectImpactODSIndicatorBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<ProjectImpact, System.Guid, ODSIndicator, System.Guid>
    {
        public System.Guid ProwId { get; set; }

        public System.Guid SternId { get; set; }

        public ProjectImpact Prow { get; set; }

        public ODSIndicator Stern { get; set; }
    }
}
