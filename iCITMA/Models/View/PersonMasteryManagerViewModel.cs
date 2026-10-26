namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class PersonMasteryManagerViewModel
    {
        public PersonDisplayViewModel Person { get; set; }
        public System.Collections.Generic.ICollection<ResearchAreaDisplayViewModel> Masterys { get; set; }
        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> NotSelectedMasterys { get; set; }
    }
}
