using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class PhoneContactInputViewModel : MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<PhoneContactItem, System.Guid>
    {
        public Guid Id { get; set; }

        [Display(Name = "Label")]
        public string Label { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Phone(ErrorMessage = "PhoneValidationErrorMessage")]
        [Display(Name = "Number")]
        public string Number { get; set; }

        public PhoneContactItem Export()
        {
            var entity = new PhoneContactItem();

            Mergue(entity);

            return entity;
        }

        public void Import(PhoneContactItem entity)
        {
            Label = entity.Label;
            Number = entity.PhoneNumber;
        }

        public void Mergue(PhoneContactItem entity)
        {
            entity.Label = Label;
            entity.PhoneNumber = Number;
        }
    }
}
