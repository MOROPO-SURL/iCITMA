using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectCategoryInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<ProjectCategory, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }

        public ProjectCategory Export()
        {
            var entity = new ProjectCategory();

            Mergue(entity);

            return entity;
        }

        public void Import(ProjectCategory entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
        }

        public void Mergue(ProjectCategory entity)
        {
            entity.Name = Name;
            entity.Description = Description;
        }
    }
}

