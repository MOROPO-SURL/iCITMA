namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProjectInstitutionParticipationBridge
    {
        public System.Guid ProjectId { get; set; }

        public System.Guid InstitutionId { get; set; }

        public Project Project { get; set; }

        public Institution Institution { get; set; }
    }
}
