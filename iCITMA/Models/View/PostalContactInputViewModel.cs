using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class PostalContactInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<PostalContactItem, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid ContextId { get; set; }

        [Display(Name = "Label")]
        public string Label { get; set; }
        
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Direction")]
        public string Address { get; set; }
        
        [Display(Name = "ZipCode")]
        public int? ZipCode { get; set; }
        
        [Display(Name = "Longitude")]
        public decimal? Longitude { get; set; }
        
        [Display(Name = "Latitude")]
        public decimal? Latitude { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "State")]
        public System.Guid StateId { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Municipality")]
        public System.Guid MunicipalityId { get; set; }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectListItem[] SelectMunicipalities { get; set; }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectListItem[] SelectStates { get; set; }

        public PostalContactItem Export()
        {
            var entity = new PostalContactItem();

            Mergue(entity);

            return entity;
        }
        

        public void Import(PostalContactItem entity)
        {
            Label = entity.Label;
            Address = entity.Address;
            ZipCode = entity.ZipCode == 0 ? null : entity.ZipCode;
            Latitude = entity.Latitude == 0 ? null : entity.Latitude;
            Longitude = entity.Longitude == 0 ? null : entity.Longitude;
        }

        public void Mergue(PostalContactItem entity)
        {
            entity.Label = Label;
            entity.Address = Address;
            entity.ZipCode = ZipCode ?? 0;
            entity.Latitude = Latitude ?? 0;
            entity.Longitude = Longitude ?? 0;
        }
    }
}
