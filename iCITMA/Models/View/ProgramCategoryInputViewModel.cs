using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProgramCategoryInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<ProgramCategory, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }

        public ProgramCategory Export()
        {
            var entity = new ProgramCategory();

            Mergue(entity);

            return entity;
        }

        public void Import(ProgramCategory entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
        }

        public void Mergue(ProgramCategory entity)
        {
            entity.Name = Name;
            entity.Description = Description;
        }
    }
}