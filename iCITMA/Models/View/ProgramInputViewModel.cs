using MOROPO.CITMA.CMG.iCITMA.Models.View.CustomSelect;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System.Collections.Generic;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProgramInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Program, System.Guid>
    {
        public System.Guid Id { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "RequiredValidationErrorMessage")]
        public string Name { get; set; }
        public string Code { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Manager")]
        public System.Guid? InstitutionId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Leader")]
        public System.Guid? LeaderId { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Category")]
        public System.Guid? CategoryId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime? EndAt { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Funding")]
        public System.Guid FundingSourceId { get; set; }
        public decimal? Amount { get; set; }        

        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> InstitutionSelected { get; set; }
            = new System.Collections.Generic.List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> CategorySelected { get; set; }
           = new System.Collections.Generic.List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> FundingSourceSelected { get; set; }
          = new System.Collections.Generic.List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> LeaderSelected { get; set; }
          = new System.Collections.Generic.List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        public ICollection<ProgramPersonExpertBridge> PersonExpertBridges { get; set; }
        public ICollection<ProgramKeyWordBridge> KeyWordBridges { get; set; }
        public ICollection<ProgramDocumentBridge> DocumentBridges { get; set; }

        public List<SelectionDescriptedImageItemInputViewModel<System.Guid>> ExpertsToSelect { get; set; } = new List<SelectionDescriptedImageItemInputViewModel<System.Guid>>();

        public List<Framework.Guama.Core.Presentation.Models.View.SelectionDescriptedItemInputViewModel<System.Guid>> KeyWordsToSelect { get; set; } = new List<Framework.Guama.Core.Presentation.Models.View.SelectionDescriptedItemInputViewModel<System.Guid>>();

        public List<Framework.Guama.Core.Presentation.Models.View.SelectionDescriptedItemInputViewModel<System.Guid>> DocumentsToSelect { get; set; } = new List<Framework.Guama.Core.Presentation.Models.View.SelectionDescriptedItemInputViewModel<System.Guid>>();

        public Persistence.Entities.Program Export()
        {
           var entity = new Persistence.Entities.Program();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Program entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Code = entity.Code;
            CategoryId = entity.CategoryId;
            InstitutionId = entity?.ManagerId;
            LeaderId = entity.LeaderId;
            FundingSourceId = entity.FundingSourceId;
            StartDate = entity.StartAt;
            EndAt = entity.EndAt;
            Amount = entity.Amount;
            PersonExpertBridges = entity.PersonExpertBridges;
            KeyWordBridges = entity.KeyWordBridges;
            DocumentBridges = entity.DocumentBridges;
        }

        public void Mergue(Persistence.Entities.Program entity)
        {
            entity.Name = Name;
            entity.Code = Code;
            entity.StartAt = StartDate;
            entity.EndAt = EndAt;
            entity.Amount = Amount;
            entity.CategoryId = CategoryId;
            entity.FundingSourceId = FundingSourceId;
            entity.LeaderId = LeaderId;
            entity.ManagerId = InstitutionId;
        }
    }
}
