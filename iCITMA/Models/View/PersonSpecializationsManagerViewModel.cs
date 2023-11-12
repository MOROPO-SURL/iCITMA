namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class PersonSpecializationsManagerViewModel
    {
        public PersonDisplayViewModel Person { get; set; }
        public System.Collections.Generic.ICollection<ResearchAreaDisplayViewModel> Specializations { get; set; }
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> NotSelectedSpecializations { get; set; }
    }
}
