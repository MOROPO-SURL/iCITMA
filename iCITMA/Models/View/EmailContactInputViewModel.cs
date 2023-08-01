using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class EmailContactInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<EmailContactItem, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid ContextId { get; set; }

        [Display(Name = "Label")]
        public string Label { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [EmailAddress(ErrorMessage = "EmailAddressValidationErrorMessage")]
        [Display(Name = "Email")]
        public string Address { get; set; }

        public EmailContactItem Export()
        {
            var entity = new EmailContactItem();

            Mergue(entity);

            return entity;
        }

        public void Import(EmailContactItem entity)
        {
            Label = entity.Label;
            Address = entity.EmailAddress;
        }

        public void Mergue(EmailContactItem entity)
        {
            entity.Label = Label;
            entity.EmailAddress = Address;
        }
    }
}
