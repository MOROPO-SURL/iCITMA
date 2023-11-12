namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class PersonDoctorateManagerViewModel
    {
        public PersonDisplayViewModel Person { get; set; }
        public System.Collections.Generic.ICollection<ResearchAreaDisplayViewModel> Doctorates { get; set; }
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> NotSelectedDoctorates { get; set; }
    }
}
