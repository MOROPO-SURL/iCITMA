namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities.Contract
{
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public abstract class AbstractNomenclator : SAPRESSC.Core.Persistence.Entities.IEntity<System.Guid>
    {
        public AbstractNomenclator()
        {
            Id = System.Guid.NewGuid();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
