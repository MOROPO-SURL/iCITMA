using MOROPO.CITMA.CMG.iCITMA.Models.View.CustomSelect;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProgramInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Program, System.Guid>
    {
        public System.Guid Id { get; set; }
        
        [Display(Name = "Name")]
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        public string Name { get; set; }
        
        [Display(Name = "Code")]
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        public string Code { get; set; }
        
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Manager")]
        public System.Guid? ManagerId { get; set; }
        
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Leader")]
        public System.Guid? LeaderId { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Category")]
        public System.Guid? CategoryId { get; set; }

        [Display(Name = "StartDate")]
        public System.DateTime StartDate { get; set; } = System.DateTime.Now.AddYears(-5);
        
        [Display(Name = "EndAt")] 
        public System.DateTime? EndAt { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Goals")]
        public string Description { get; set; }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectListItem[] InstitutionSelectedListItems { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectListItem[] CategorySelectedListItems { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectListItem[] LeaderSelectedListItems { get; set; }
        
        public List<ProgramPersonExpertBridge> PersonExpertBridges { get; set; }
        public List<ProgramKeyWordBridge> KeyWordBridges { get; set; }
        public List<ProgramDocumentBridge> DocumentBridges { get; set; }

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
            ManagerId = entity.ManagerId;
            LeaderId = entity.LeaderId;
            StartDate = entity.StartAt;
            EndAt = entity.EndAt;
            Description = entity.Description;
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
            entity.Description = Description;
        }
    }
}
