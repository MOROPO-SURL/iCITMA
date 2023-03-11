namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProyectSpectResult : Contract.AbstractExpectResult
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ProjectId")]
        public Project Project { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? ProjectId { get; set; }
    }
}
