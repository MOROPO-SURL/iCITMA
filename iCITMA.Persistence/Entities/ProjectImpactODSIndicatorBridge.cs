namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProjectImpactODSIndicatorBridge
    {
        public System.Guid ImapactId { get; set; }

        public System.Guid IndicatorId { get; set; }

        public ProjectImpact Impact { get; set; }

        public ODSIndicator Indicator { get; set; }
    }
}
