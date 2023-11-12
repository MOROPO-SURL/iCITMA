using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class PersonInstitutionInputViewModel
    {
        public System.Guid PersonId { get; set; }

        [Display(Name = "Institutions")]
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> NotSelectedInstitutions { get; set; } = new System.Collections.Generic.List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        [Required(ErrorMessage = "RequiredArtistValidationErrorMessage")]
        [Display(Name = "InstitutionId")]
        public System.Guid InstitutionId { get; set; }
    }
}
