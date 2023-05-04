using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class FundingSourceDisplayViewModel: Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<FundingSource, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }

        public void Import(FundingSource entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
        }
    }
}