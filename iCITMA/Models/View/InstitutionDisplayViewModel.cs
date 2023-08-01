using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Extensions;
using System.ComponentModel.DataAnnotations;

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
        public System.DateTime? CreatedAt { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public InstitutionDisplayViewModel Owner { get; set; }

        public PersonDisplayViewModel Representative { get; set; }

        [Display(Name = "Alias")]
        public string Alias { get; set; }

        public InstitutionProjectLogicViewModel InstitutionProjectLogicViewModel { get; set; }

        public void Import(Institution entity)
        {
            Id = entity.Id;
            ImageId = entity.Identity.ImageId;
            ImageExtension = entity.Identity.Image?.ContentType.ContentTypeToExtension() ?? null;
            Name = entity.Identity.Name;
            Description = entity.Identity.About;
            CreatedAt = entity.Identity.BornDate;
            Alias = entity.Alia;

            if (entity.OwnerId != null)
            {
                Owner = new InstitutionDisplayViewModel
                {
                    Id = entity.OwnerId.Value,
                    Name = entity.Owner.Identity.Name
                };
            }

            if (entity.RepresentativeId != null)
            {
                Representative = new PersonDisplayViewModel
                {
                    Id = entity.RepresentativeId.Value,
                    Name = entity.Representative.Identity.Name,
                    LastName = entity.Representative.Identity.LastName
                };
            }
        }
    }
}
