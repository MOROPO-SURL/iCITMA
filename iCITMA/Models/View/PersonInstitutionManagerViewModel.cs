namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class PersonInstitutionManagerViewModel
    {
        public PersonDisplayViewModel Person { get; set; }
        public System.Collections.Generic.ICollection<InstitutionDisplayViewModel> Institutions { get; set; }

        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> NotSelectedInstitutions { get; set; }
    }
}
