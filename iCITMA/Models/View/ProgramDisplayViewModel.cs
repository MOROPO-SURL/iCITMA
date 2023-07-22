

using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProgramDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Program, System.Guid>
    {
        public System.Guid Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Code")]
        public string Code { get; set; }
        [Display(Name = "Manager")]
        public string Institution { get; set; }
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Display(Name = "Leader")]
        public string Leader { get; set; }
        [Display(Name = "FundingSource")]
        public string FundingSource { get; set; }
        [Display(Name = "StartDate")]
        public System.DateTime StartDate { get; set; }
        [Display(Name = "EndAt")]
        public System.DateTime? EndAt { get; set; }
        [Display(Name = "Amount")]
        public decimal? Amount { get; set; }
        public ICollection<ProgramPersonExpertBridge> PersonExpertBridges { get; set; }
        public ICollection<ProgramKeyWordBridge> KeyWordBridges { get; set; }
        public ICollection<ProgramDocumentBridge> DocumentBridges { get; set; }

        public void Import(Persistence.Entities.Program entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Code = entity.Code;
            Institution = entity.Manager.Identity.Name;
            Category = entity.Category.Name;
            Leader = entity.Leader.Identity.Name + " " + entity.Leader.Identity.LastName;
            FundingSource = entity.FundingSource.Name;
            StartDate = entity.StartAt;
            EndAt = entity.EndAt;
            Amount = entity.Amount;
            PersonExpertBridges = entity.PersonExpertBridges;
            KeyWordBridges = entity.KeyWordBridges;
            DocumentBridges = entity.DocumentBridges;
        }
    }
}
