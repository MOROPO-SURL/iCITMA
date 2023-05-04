namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class Funding : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        public Funding()
        {
            Id = System.Guid.NewGuid();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ProgramId")]
        public Program Program { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? ProgramId { get; set; }

        public FundingSource Source { get; set; }
        public System.Guid? SourceId { get; set; }

        public decimal Mount { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("CurrentcyId")]
        public Currency Currency { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public int? CurrentcyId { get; set; }
    }
}
