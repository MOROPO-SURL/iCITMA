using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class InstitutionParticipationInputViewModel
    {
        public System.Guid ProjectId { get; set; }

        [Display(Name = "Participant")]
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> NotSelectedParticipants { get; set; } = new System.Collections.Generic.List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        [Required(ErrorMessage = "RequiredArtistValidationErrorMessage")]
        [Display(Name = "InstitutionId")]
        public System.Guid InstitutionId { get;  set; }
    }
}
