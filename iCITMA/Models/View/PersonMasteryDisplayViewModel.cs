using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class PersonMasteryDisplayViewModel
    {
        public System.Guid PersonId { get; set; }

        [Display(Name = "Masterys")]
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> NotSelectedMasterys { get; set; } = new System.Collections.Generic.List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        [Required(ErrorMessage = "RequiredArtistValidationErrorMessage")]
        [Display(Name = "ResearchArea")]
        public System.Guid ResearchAreaId { get; set; }
    }
}
