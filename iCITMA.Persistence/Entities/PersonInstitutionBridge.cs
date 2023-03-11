namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class PersonInstitutionBridge
    {
        public System.Guid PersonId { get; set; }

        public System.Guid InstitutionId { get; set; }

        public Person Person { get; set; }

        public Institution Institution { get; set; }
    }
}
