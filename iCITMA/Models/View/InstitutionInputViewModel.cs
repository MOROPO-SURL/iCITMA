using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Presentation.Web.Common.ComponentModel.DataAnnotations;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Extensions;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class InstitutionInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<MOROPO.CITMA.CMG.iCITMA.Persistence.Entities.Institution, System.Guid>
    {
        public System.Guid Id { get; set; }

        [FormFileContentTypes(ContentTypes = new string[] { "image/png", "image/jpeg" }, ErrorMessage = "PNG_JPEG_FileAllowedOnlyMessage")]
        [FormFileMaxLength(Length = 3145728, ErrorMessage = "FileLimitSizeExcededMessage")]
        [Display(Name = "ImageFile")]
        public Microsoft.AspNetCore.Http.IFormFile ImageFile { get; set; }

        public System.Guid? ImageId { get; set; }

        public string ImageExtension { get; set; }

        public bool ResetImage { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Alias")]
        public string Alia { get;set; }

        [Display(Name = "CreatedAt")]
        public System.DateTime? CreatedAt { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }        

        [Display(Name = "Owner")]
        public System.Guid? OwnerId { get; set; }

        [Display(Name = "Representative")]
        public System.Guid? RepresentativeId { get; set; }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectListItem[] OwnerSelectedListItems { get; set; }
        public Microsoft.AspNetCore.Mvc.Rendering.SelectListItem[] PersonSelectedListItems { get; set; }

        public Institution Export()
        {
            var entity = new Institution();

            Mergue(entity);

            return entity;
        }

        public void Import(Institution entity)
        {
            Id = entity.Id;
            ImageId = entity.Identity.ImageId;
            ImageExtension = entity.Identity.Image?.ContentType.ContentTypeToExtension() ?? null;
            Name = entity.Identity.Name;
            Alia = entity.Alia;
            CreatedAt = entity.Identity.BornDate;
            Description = entity.Identity.About;
            OwnerId = entity.OwnerId;
            RepresentativeId = entity.RepresentativeId;
        }

        public void Mergue(Institution entity)
        {                      
            entity.Identity.Name = Name;
            entity.Alia = Alia;
            entity.Identity.BornDate = CreatedAt;
            entity.Identity.About = Description;
        }
    }
}
