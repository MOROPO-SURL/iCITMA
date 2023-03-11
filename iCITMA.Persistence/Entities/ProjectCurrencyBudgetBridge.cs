namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProjectCurrencyBudgetBridge
    {
        public System.Guid ProjectId { get; set; }

        public int CurrencyId { get; set; }

        public Project Project { get; set; }

        public decimal Mount { get; set; }

        public Currency Currency { get; set; }
    }
}
