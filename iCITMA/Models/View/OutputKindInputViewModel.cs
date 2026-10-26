using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class OutputKindInputViewModel: Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<OutputKind, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "RequiredValidationErrorMessage")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }

        public OutputKind Export()
        {
            var entity = new OutputKind();

            Mergue(entity);

            return entity;
        }

        public void Import(OutputKind entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
        }

        public void Mergue(OutputKind entity)
        {
            entity.Name = Name;
            entity.Description = Description;
        }
    }
}