namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class PersonResearchAreaMasteryBridge
    {
        public System.Guid PersonId { get; set; }

        public System.Guid ResearchAreaId { get; set; }

        public Person Person { get; set; }

        public ResearchArea ResearchArea { get; set; }
    }
}
