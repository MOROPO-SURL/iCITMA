namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class PersonInstitutionBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Person, System.Guid, Institution, System.Guid>
    {
        public System.Guid ProwId { get; set; }

        public Person Prow { get; set; }

        public System.Guid SternId { get; set; }

        public Institution Stern { get; set; }
    }
}
