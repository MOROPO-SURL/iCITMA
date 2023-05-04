namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProjectCurrencyBudgetBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Project, System.Guid, Currency, int>
    {
        public System.Guid ProwId { get; set; }

        public int SternId { get; set; }

        public Project Prow { get; set; }

        public Currency Stern { get; set; }

        public decimal Mount { get; set; }
    }
}
