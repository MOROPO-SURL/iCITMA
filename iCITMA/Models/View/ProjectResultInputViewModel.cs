using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectResultInputViewModel: Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<ProjectResult, Guid>
    {
        public Guid Id { get; set; }

        [Display(Name = "Result")]
        [Required(ErrorMessage = "El resultado es requerido")]
        public string Result { get; set; }

        [Display(Name = "ProjectId")]
        public System.Guid ProjectId { get; set; }

        public ProjectResult Export()
        {
            var entity = new ProjectResult();

            Mergue(entity);

            return entity;
        }

        public void Import(ProjectResult entity)
        {
            Id = entity.Id;
            Result = entity.Result;
            ProjectId = (Guid)entity.ProjectId;
        }

        public void Mergue(ProjectResult entity)
        {
            entity.Result = Result;
        }
    }
}
