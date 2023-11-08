using System.ComponentModel.DataAnnotations;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProgramKeyWordInputViewModel
    {
        public System.Guid ProgramId { get; set; }

        [Display(Name = "keyWord")]
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> NotSelectedKeyWords { get; set; } = new System.Collections.Generic.List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        [Required(ErrorMessage = "RequiredArtistValidationErrorMessage")]
        [Display(Name = "KeyWordId")]
        public System.Guid KeyWordId { get; set; }
    }
}
