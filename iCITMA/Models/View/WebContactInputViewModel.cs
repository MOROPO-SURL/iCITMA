using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class WebContactInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<WebSiteContactItem, System.Guid>
    {
        public Guid Id { get; set; }
        [Required]
        [Url]
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
        }
        public void Mergue(WebSiteContactItem entity)
        {
            entity.Url = Url;
        }
    }
}
