namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProgramInstitutionResponsibleBridge
    {
        public System.Guid ProgramId { get; set; }

        public System.Guid InstitutionId { get; set; }

        public Program Program { get; set; }

        public Institution Institution { get; set; }
    }
}
