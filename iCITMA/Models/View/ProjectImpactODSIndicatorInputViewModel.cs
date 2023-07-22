using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectImpactODSIndicatorInputViewModel
    {
        public System.Guid ODSIndicatorId { get; set; }
        public System.Guid ProjectImpactId { get; set; }
        [Display(Name = "ODSIndicator")]
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> NotSelectedODS { get; set; } = new System.Collections.Generic.List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
    }
}
