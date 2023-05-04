using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ImpactIndicatorInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<ImpactIndicator, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }

        public ImpactIndicator Export()
        {
            var entity = new ImpactIndicator();

            Mergue(entity);

            return entity;
        }

        public void Import(ImpactIndicator entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
        }

        public void Mergue(ImpactIndicator entity)
        {
           entity.Name = Name;
           entity.Description = Description;           
        }
    }
}
