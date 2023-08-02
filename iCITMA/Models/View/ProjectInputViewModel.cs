using Microsoft.AspNetCore.Mvc.Rendering;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Project, System.Guid>
    {
        public ProjectInputViewModel()
        {
            StartAt = System.DateTime.Now;
        }

        public System.Guid Id { get; set; }
        
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Code")]
        public string Code { get; set; }
        
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Program")]
        public System.Guid? ProgramId { get; set; }
        public SelectListItem[] ProgramSelectListItems { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Category")]
        public System.Guid? CategoryId { get; set; }
        public SelectListItem[] CategorySelectListItems { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "MainExecutor")]
        public System.Guid? ManagerId { get; set; }
        public SelectListItem[] InstitutionSelectListItems { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Leader")]
        public System.Guid? LeaderId { get; set; }
        public SelectListItem[] PersonSelectListItems { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Status")]
        public System.Guid? StateId { get; set; }
        public SelectListItem[] StateSelectListItems { get; set; }

        [Display(Name = "StartAt")]      
        public System.DateTime StartAt { get; set; }

        [Display(Name = "EndAt")]        
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
        [Display(Name = "MainObjetive")]
        public string MainObjetive { get; set; }

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
            ProgramId = entity.ProgramId;
            CategoryId = entity.CategoryId;
            ManagerId = entity.ManagerId;
            LeaderId = entity.LeaderId;
            StateId = entity.StateId;
            StartAt = entity.StartAt;
            EndAt = entity.EndAt;
            Budget = entity.Budget;
            Summary = entity.Summary;
            Problem = entity.Problem;
            Context = entity.Context;
            Beneficiary = entity.Beneficiary;
            MainObjetive = entity.MainObjetive;
        }

        public void Mergue(Project entity)
        {
            entity.Title = Title;
            entity.Code = Code;
            entity.StartAt = StartAt;
            entity.EndAt = EndAt;
            entity.Budget = Budget;
            entity.Summary = Summary;
            entity.Problem = Problem;
            entity.Context = Context;
            entity.Beneficiary = Beneficiary;
            entity.MainObjetive = MainObjetive;
        }
    }
}
