namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class PersonResearchAreaDoctorateBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Person, System.Guid, ResearchArea, System.Guid>
    {
        public System.Guid ProwId { get; set; }

        public Person Prow { get; set; }

        public System.Guid SternId { get; set; }

        public ResearchArea Stern { get; set; }
    }
}
