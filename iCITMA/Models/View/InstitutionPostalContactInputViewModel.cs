using MOROPO.Framework.Guama.Location.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class InstitutionPostalContactInputViewModel: PostalContactInputViewModel
    {
        public System.Guid InstitutionId { get; set; }

        public System.Guid StateId { get; set; }
        public State State { get; set; }
        public System.Guid MunicipalityId { get; set; }
        public Municipality Municipality { get; set; }

        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> SelectMunicipalities { get; set; } =
            new System.Collections.Generic.List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> SelectStates { get; set; } =
           new System.Collections.Generic.List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
    }
}
