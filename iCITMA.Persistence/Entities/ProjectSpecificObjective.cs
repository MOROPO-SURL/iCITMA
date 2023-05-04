namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class ProjectSpecificObjective : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        public ProjectSpecificObjective()
        {
            Id = System.Guid.NewGuid();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ProjectId")]
        public Project Project { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? ProjectId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }
    }
}
