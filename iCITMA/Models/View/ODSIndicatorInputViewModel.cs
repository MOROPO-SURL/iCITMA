using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using System;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ODSIndicatorInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<ODSIndicator, System.Guid>
    {
        public Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "RequiredValidationErrorMessage")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Description")]
        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Reference")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "RequiredValidationErrorMessage")]
        public string Reference { get; set; }

        public ODSIndicator Export()
        {
            var entity = new ODSIndicator();

            Mergue(entity);

            return entity;
        }

        public void Import(ODSIndicator entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Reference = entity.Reference;
        }

        public void Mergue(ODSIndicator entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Reference = Reference;
        }
    }
}
