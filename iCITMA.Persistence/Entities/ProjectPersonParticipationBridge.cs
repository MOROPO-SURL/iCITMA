namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProjectPersonParticipationBridge
    {
        public System.Guid ProjectId { get; set; }

        public System.Guid PersonId { get; set; }

        public Project Project { get; set; }

        public Person Person { get; set; }
    }
}
