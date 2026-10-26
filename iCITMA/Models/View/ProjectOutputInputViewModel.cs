using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System;
using System.Collections.Generic;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectOutputInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<ProjectOutput, System.Guid>
    {
        public Guid Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? ProjectId { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid OutputKindId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = " Se debe seleccionar una salida")]
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> OutputKindSelected { get; set; }
            = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = " Se debe poner una descripción")]
        public string Description { get; set; }

        public ProjectOutput Export()
        {
            var entity = new ProjectOutput();

            Mergue(entity);

            return entity;
        }

        public void Import(ProjectOutput entity)
        {
            Id = entity.Id;
            ProjectId = entity.ProjectId;
            OutputKindId = (System.Guid)entity.KindId;
            Description = entity.Description;
        }

        public void Mergue(ProjectOutput entity)
        {
            entity.ProjectId = ProjectId;
            entity.Description = Description;

        }
    }
}
