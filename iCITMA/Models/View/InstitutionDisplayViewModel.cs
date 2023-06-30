using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Drawing2D;
using System.Xml.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class InstitutionDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<MOROPO.CITMA.CMG.iCITMA.Persistence.Entities.Institution, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid? ImageId { get; set; }

        public string ImageExtension { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime? CreatedAt { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public Institution Owner { get; set; }

        public Person Representative { get; set; }

        [Display(Name = "Alias")]
        public string Alia { get; set; }

        public void Import(Institution entity)
        {
            Id = entity.Id;
            ImageId = entity.Identity.ImageId;
            ImageExtension = entity.Identity.Image?.ContentType.ContentTypeToExtension() ?? null;
            Name = entity.Identity.Name;
            Description = entity.Identity.About;
            Owner = entity?.Owner;
            Representative = entity.Representative;
            CreatedAt = entity.Identity.BornDate;
            Alia = entity.Alia;
        }
    }
}
