using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class PostalContactInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<PostalContactItem, System.Guid>
    {
        public System.Guid Id { get; set; }
        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Direction")]
        public string Address { get; set; }
        public Framework.Guama.Location.Persistence.Entities.Location Location { get; set; }
        public System.Guid LocationId { get; set; }
        [Display(Name = "ZipCode")]
        public int ZipCode { get; set; }
        [Display(Name = "Longitude")]
        public decimal Longitude { get; set; }
        [Display(Name = "Latitude")]
        public decimal Latitude { get; set; }

        public PostalContactItem Export()
        {
            var entity = new PostalContactItem();

            Mergue(entity);

            return entity;
        }
        

        public void Import(PostalContactItem entity)
        {
            Address = entity.Address;
            Location = entity.Location;
            LocationId = (System.Guid)entity.LocationId;
            ZipCode = entity.ZipCode;
            Latitude = entity.Latitude;
            Longitude = entity.Longitude;
        }

        public void Mergue(PostalContactItem entity)
        {
            entity.Address = Address;
            entity.Location = Location;
            entity.LocationId = LocationId;
            entity.ZipCode = ZipCode;
            entity.Latitude = Latitude;
            entity.Longitude = Longitude; 

        }
    }
}
