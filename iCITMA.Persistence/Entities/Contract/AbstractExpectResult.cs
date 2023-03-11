namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities.Contract
{
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public abstract class AbstractExpectResult : SAPRESSC.Core.Persistence.Entities.IEntity<System.Guid>
    {
        public AbstractExpectResult()
        {
            Id = System.Guid.NewGuid();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }
    }
}
