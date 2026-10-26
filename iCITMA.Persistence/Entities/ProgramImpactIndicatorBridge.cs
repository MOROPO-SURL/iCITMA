namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProgramImpactIndicatorBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Program, System.Guid, ImpactIndicator, System.Guid>
    {
        public System.Guid ProwId { get; set; }

        public System.Guid SternId { get; set; }

        public Program Prow { get; set; }

        public ImpactIndicator Stern { get; set; }
    }
}
