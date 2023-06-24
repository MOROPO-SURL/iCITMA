using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Presentation.Web.Common.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class DocumentInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<MOROPO.CITMA.CMG.iCITMA.Persistence.Entities.Document, System.Guid>
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [FormFileContentTypes(ContentTypes = new string[] { "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "image/jpeg", "image/png", "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" }, ErrorMessage = "DOCs_FileAllowedOnlyMessage")]
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "File")]
        public Microsoft.AspNetCore.Http.IFormFile File { get; set; }

        public string ContentType { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public System.Guid? ThumbnailId { get; set; }
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> ThumbnailSelected { get; set; }
            = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();

        public Document Export()
        {
            var entiy = new Document();

            Mergue(entiy);

            return entiy;
        }

        public void Import(Document entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            ContentType = entity.ContentType;
            Description = entity.Description;
        }

        public void Mergue(Document entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.ContentType = ContentType;
        }
    }
}
