using System.Collections.Generic;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class Project : SAPRESSC.Core.Persistence.Entities.IEntity<System.Guid>
    {
        public Project()
        {
            Id = System.Guid.NewGuid();

            ProgramExpectResultBridges = new List<ProjectProgramExpectResultBridge>();
            InstitutionParticipationBridges = new List<ProjectInstitutionParticipationBridge>();
            CurrencyBudgetBridges = new List<ProjectCurrencyBudgetBridge>();
            KeyWordBridges = new List<ProjectKeyWordBridge>();
            InstitutionClientBridges = new List<ProjectInstitutionClientBridge>();
            PersonParticipationBridges = new List<ProjectPersonParticipationBridge>();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public ProjectState State { get; set; }
        public System.Guid? StateId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Code { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ProgramId")]
        public Program Program { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? ProgramId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("CategoryId")]
        public ProjectCategory Category { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? CategoryId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ManagerId")]
        public Institution Manager { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? ManagerId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("LeaderId")]
        public Person Leader { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? LeaderId { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime? EndAt { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Summary { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Problem { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Context { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Beneficiary { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string MainObjetive { get; set; }

        public List<ProjectProgramExpectResultBridge> ProgramExpectResultBridges { get; set; }

        public List<ProjectInstitutionParticipationBridge> InstitutionParticipationBridges { get; set; }

        public List<ProjectCurrencyBudgetBridge> CurrencyBudgetBridges { get; set; }

        public List<ProjectKeyWordBridge> KeyWordBridges { get; set; }

        public List<ProjectInstitutionClientBridge> InstitutionClientBridges { get; set; }

        public List<ProjectPersonParticipationBridge> PersonParticipationBridges { get; set; }
    }
}
