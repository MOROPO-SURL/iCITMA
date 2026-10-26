namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProjectPersonParticipationBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Project, System.Guid, Person, System.Guid>
    {
        public System.Guid ProwId { get; set; }

        public System.Guid SternId { get; set; }

        public Project Prow { get; set; }

        public Person Stern { get; set; }
    }
}
