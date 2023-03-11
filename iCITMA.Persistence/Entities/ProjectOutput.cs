namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProjectOutput : SAPRESSC.Core.Persistence.Entities.IEntity<System.Guid>
    {
        public ProjectOutput()
        {
            Id = System.Guid.NewGuid();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ProjectId")]
        public Project Project { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? ProjectId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("KindId")]
        public OutputKind Kind { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? KindId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }
    }
}
