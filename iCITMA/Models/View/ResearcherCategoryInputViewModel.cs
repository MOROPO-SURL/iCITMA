using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ResearcherCategoryInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<ResearcherCategory, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }

        public ResearcherCategory Export()
        {
            var entity = new ResearcherCategory();

            Mergue(entity);

            return entity;
        }

        public void Import(ResearcherCategory entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
        }

        public void Mergue(ResearcherCategory entity)
        {
            entity.Name = Name;
            entity.Description = Description;
        }
    }
}
