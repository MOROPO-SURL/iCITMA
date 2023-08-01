using MOROPO.Framework.Guama.Location.Persistence.Entities;
using System.ComponentModel;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class InstitutionPostalContactInputViewModel : PostalContactInputViewModel
    {
        public System.Guid InstitutionId { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [DisplayName("State")]
        public System.Guid StateId { get; set; }

        public State State { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [DisplayName("Municipality")]
        public System.Guid MunicipalityId { get; set; }

        public Municipality Municipality { get; set; }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectListItem[] SelectMunicipalities { get; set; }
        
        public Microsoft.AspNetCore.Mvc.Rendering.SelectListItem[] SelectStates { get; set; }
    }
}
