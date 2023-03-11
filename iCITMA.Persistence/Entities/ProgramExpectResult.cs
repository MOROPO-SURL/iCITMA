namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProgramExpectResult : Contract.AbstractExpectResult
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ProgramId")]
        public Program Program { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? ProgramId { get; set; }
    }
}
