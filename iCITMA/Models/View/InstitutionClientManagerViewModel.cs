namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class InstitutionClientManagerViewModel
    {
        public ProjectDisplayViewModel Project { get; set; }
        public System.Collections.Generic.ICollection<InstitutionDisplayViewModel> Clients { get; set; }

        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> NotSelectedClients { get; set; }
    }
}
