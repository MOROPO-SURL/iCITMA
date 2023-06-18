using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Presentation.Web.Common.ComponentModel.DataAnnotations;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Xml.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class InstitutionInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<MOROPO.CITMA.CMG.iCITMA.Persistence.Entities.Institution, System.Guid>
    {
        public Guid Id { get; set; }

        [FormFileContentTypes(ContentTypes = new string[] { "image/png", "image/jpeg" }, ErrorMessage = "PNG_JPEG_FileAllowedOnlyMessage")]
        [FormFileMaxLength(Length = 3145728, ErrorMessage = "FileLimitSizeExcededMessage")]
        [Display(Name = "ImageFile")]
        public Microsoft.AspNetCore.Http.IFormFile ImageFile { get; set; }

        public System.Guid? ImageId { get; set; }

        public string ImageExtension { get; set; }

        public bool ResetImage { get; set; }       

        public string Name { get; set; }
        [Display(Name = "Stage name")]
        public string Alia { get;set; }
        [Display(Name = "CreatedAt")]
        public DateTime? CreatedAt { get; set; }
        public string Description { get; set; }
        [Display(Name = "Owner")]

        public System.Guid? OwnerId { get; set; }
        [Display(Name = "Representative")]
        public System.Guid? RepresentativeId { get; set; }
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> OwnwerSelected { get; set; }
            = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> RepresentativeSelected { get; set; }
            = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();

        public Institution Export()
        {
            var entity = new Institution();

            Mergue(entity);

            return entity;
        }

        public void Import(Institution entity)
        {
            Id = entity.Id;
            ImageId = entity.Identity.Image?.Id ?? System.Guid.Empty;
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
            //TODO Se debe incluir las imagenes ImageFile, ImageId, etc            
            entity.Identity.Name = Name;
            entity.Alia = Alia;
            entity.Identity.BornDate = CreatedAt;
            entity.OwnerId = OwnerId;
            entity.Identity.About = Description;
            entity.RepresentativeId = RepresentativeId;
        }
    }
}
