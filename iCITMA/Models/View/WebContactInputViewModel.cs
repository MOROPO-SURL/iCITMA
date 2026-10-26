using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class WebContactInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<WebSiteContactItem, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid ContextId { get; set; }

        [Display(Name = "Label")]
        public string Label { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Url(ErrorMessage = "UrlValidationErrorMessage")]
        [Display(Name = "Url")]
        public string Url { get; set; }

        public WebSiteContactItem Export()
        {
            var entity = new WebSiteContactItem();

            Mergue(entity);

            return entity;
        }

        public void Import(WebSiteContactItem entity)
        {
            Url = entity.Url;
            Label = entity.Label;
        }
        public void Mergue(WebSiteContactItem entity)
        {
            entity.Url = Url;
            entity.Label = Label;
        }
    }
}
