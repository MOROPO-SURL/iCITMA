namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProgramImpactIndicatorBridge
    {
        public System.Guid ProgramId { get; set; }

        public System.Guid ImpactIndicatorId { get; set; }

        public Program Program { get; set; }

        public ImpactIndicator ImpactIndicator { get; set; }
    }
}
