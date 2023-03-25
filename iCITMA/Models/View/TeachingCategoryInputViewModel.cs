using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class TeachingCategoryInputViewModel : SAPRESSC.Core.Persistence.Models.IEntityInputModel<TeachingCategory, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }

        public TeachingCategory Export()
        {
            var entity = new TeachingCategory();

            Mergue(entity);

            return entity;
        }

        public void Import(TeachingCategory entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
        }

        public void Mergue(TeachingCategory entity)
        {
            entity.Name = Name;
            entity.Description = Description;
        }
    }
}
