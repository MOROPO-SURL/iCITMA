using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class FundingSourceInputViewModel: Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<FundingSource, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "RequiredValidationErrorMessage")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }

        public FundingSource Export()
        {
            var entity = new FundingSource();

            Mergue(entity);

            return entity;
        }

        public void Import(FundingSource entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
        }

        public void Mergue(FundingSource entity)
        {
            entity.Name = Name;
            entity.Description = Description;
        }
    }
}