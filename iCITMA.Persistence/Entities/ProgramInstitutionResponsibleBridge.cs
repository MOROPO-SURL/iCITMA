namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProgramInstitutionResponsibleBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Program, System.Guid, Institution, System.Guid>
    {
        public System.Guid ProwId { get; set; }

        public System.Guid SternId { get; set; }

        public Program Prow { get; set; }

        public Institution Stern { get; set; }
    }
}
