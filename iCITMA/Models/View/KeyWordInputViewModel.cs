using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class KeyWordInputViewModel : SAPRESSC.Core.Persistence.Models.IEntityInputModel<KeyWord, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }

        public KeyWord Export()
        {
            var entity = new KeyWord();

            Mergue(entity);

            return entity;
        }

        public void Import(KeyWord entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
        }

        public void Mergue(KeyWord entity)
        {
            entity.Name = Name;
            entity.Description = Description;
        }
    }
}