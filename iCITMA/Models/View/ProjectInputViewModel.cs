using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Project, System.Guid>
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        public string Title { get; set; }
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        public string Code { get; set; }
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Program")]
        public System.Guid ProgramId { get; set; }
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> ProgramSelected { get; set; }
            = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Category")]
        public System.Guid CategoryId { get; set; }
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> CategorySelected { get; set; }
            = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Principal Executor")]
        public System.Guid ManagerId { get; set; }
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> ManagerSelected { get; set; }
            = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Boss")]
        public System.Guid LeaderId { get; set; }
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> LeaderSelected { get; set; }
            = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        [Display(Name = "ProjectState")]
        public System.Guid ProjectStateId { get; set; }
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> ProjectStateSelected { get; set; }
            = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        [Display(Name = "Start At")]
        [DataType(DataType.Date)]        
        public System.DateTime StartAt { get; set; } = DateTime.Now;
        [Display(Name = "End At")]        
        public System.DateTime? EndAt { get; set; }
        [Display(Name = "Budget")]
        public decimal? Budget { get; set; }
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Summary")]
        public string Summary { get; set; }
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Problem")]
        public string Problem { get; set; }
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Context")]
        public string Context { get; set; }
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Beneficiary")]
        public string Beneficiary { get; set; }
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Main Objetive")]
        public string MainObjetive { get; set; }

        public List<ProjectProgramExpectResultBridge> ProgramExpectResultBridges { get; set; }

        public List<Framework.Guama.Core.Presentation.Models.View.SelectionDescriptedItemInputViewModel<System.Guid>> KeyWordsToSelect { get; set; } = new List<Framework.Guama.Core.Presentation.Models.View.SelectionDescriptedItemInputViewModel<System.Guid>>();

        public Project Export()
        {
            var entity = new Project();

            Mergue(entity);

            return entity;
        }

        public void Import(Project entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            Code = entity.Code;
            ProgramId = (Guid)entity.ProgramId;
            CategoryId = (Guid)entity.CategoryId;
            ManagerId = (Guid)entity.ManagerId;
            LeaderId = (Guid)entity.LeaderId;
            ProjectStateId = (Guid)entity.StateId;
            StartAt = entity.StartAt;
            EndAt = entity.EndAt;
            Budget = entity.Budget;
            Summary = entity.Summary;
            Problem = entity.Problem;
            Context = entity.Context;
            Beneficiary = entity.Beneficiary;
            MainObjetive = entity.MainObjetive;
            ProgramExpectResultBridges = entity.ProgramExpectResultBridges;
        }

        public void Mergue(Project entity)
        {
            entity.Title = Title;
            entity.Code = Code; 
            entity.ProgramId = ProgramId;
            entity.CategoryId = CategoryId;
            entity.ManagerId = ManagerId;
            entity.LeaderId = LeaderId;
            entity.StateId = ProjectStateId;
            entity.StartAt = StartAt;
            entity.EndAt = EndAt;
            entity.Budget = Budget;
            entity.Summary = Summary;
            entity.Problem = Problem;
            entity.Context = Context;
            entity.Beneficiary = Beneficiary;
            entity.MainObjetive = MainObjetive;
            entity.ProgramExpectResultBridges = ProgramExpectResultBridges;
        }
    }
}
