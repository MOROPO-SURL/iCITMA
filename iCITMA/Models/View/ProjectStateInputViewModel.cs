using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectStateInputViewModel: Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<ProjectState, System.Guid>
    {
        public Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }

        public ProjectState Export()
        {
            var entity = new ProjectState();

            Mergue(entity);

            return entity;
        }

        public void Import(ProjectState entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
        }

        public void Mergue(ProjectState entity)
        {
            entity.Name = Name;
            entity.Description = Description;
        }
    }
}
