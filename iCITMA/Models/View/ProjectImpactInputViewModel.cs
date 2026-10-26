using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectImpactInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<ProjectImpact, System.Guid>
    {
        public Guid Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "RequiredValidationErrorMessage")]
        public System.Guid? ProjectId { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "ImpactIndicators")]
        public System.Guid ImpactIndicatorId { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "RequiredValidationErrorMessage")]
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> ImpactIndicatorSelected { get; set; }
            = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public List<ProjectImpactProgramExpectResultBridge> ProgramExpectResultBridges { get; set; }

        public List<ProjectImpactODSIndicatorBridge> ODSIndicatorBridges { get; set; }

        public ProjectImpact Export()
        {
            var entity = new ProjectImpact();

            Mergue(entity);

            return entity;
        }

        public void Import(ProjectImpact entity)
        {
            Id = entity.Id;
            ProjectId = entity.ProjectId;
            Description = entity.Description;
            ODSIndicatorBridges = entity.ODSIndicatorBridges;
            ProgramExpectResultBridges = entity.ProgramExpectResultBridges;
        }

        public void Mergue(ProjectImpact entity)
        {
            entity.ProjectId = ProjectId;
            entity.Description = Description;
        }
    }
}
