using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class Program : Framework.Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>
    {
        public Program()
        {
            Id = System.Guid.NewGuid();

            ImpactIndicatorBridges = new List<ProgramImpactIndicatorBridge>();
            PersonExpertBridges = new List<ProgramPersonExpertBridge>();
            KeyWordBridges = new List<ProgramKeyWordBridge>();
            DocumentBridges = new List<ProgramDocumentBridge>();
            InstitutionResponsibleBridges = new List<ProgramInstitutionResponsibleBridge>();
        }

        [Key]
        public System.Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("CategoryId")]
        public ProgramCategory Category { get; set; }
        public System.Guid CategoryId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ManagerId")]
        public Institution Manager { get; set; }
        public System.Guid ManagerId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("LeaderId")]
        public Person Leader { get; set; }        
        public System.Guid LeaderId { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime? EndAt { get; set; }

        // Objetivos
        [Required]
        public string Description { get; set; }
        
        public List<ProgramImpactIndicatorBridge> ImpactIndicatorBridges { get; set; }

        public List<ProgramPersonExpertBridge> PersonExpertBridges { get; set; }

        public List<ProgramKeyWordBridge> KeyWordBridges { get; set; }

        public List<ProgramDocumentBridge> DocumentBridges { get; set; }

        public List<ProgramInstitutionResponsibleBridge> InstitutionResponsibleBridges { get; set; }
    }
}
