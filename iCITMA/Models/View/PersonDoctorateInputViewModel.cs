using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class PersonDoctorateInputViewModel
    {
        public System.Guid PersonId { get; set; }

        [Display(Name = "Doctorates")]
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> NotSelectedDoctorates { get; set; } = new System.Collections.Generic.List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        [Required(ErrorMessage = "RequiredArtistValidationErrorMessage")]
        [Display(Name = "ResearchAreaId")]
        public System.Guid ResearchAreaId { get; set; }
    }
}
