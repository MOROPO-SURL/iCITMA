namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProjectInstitutionParticipationBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Project, System.Guid, Institution, System.Guid>
    {
        public System.Guid ProwId { get; set; }

        public System.Guid SternId { get; set; }

        public Project Prow { get; set; }

        public Institution Stern { get; set; }
    }
}
