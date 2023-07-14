namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class InstitutionParticipationManagerViewModel
    {
        public ProjectDisplayViewModel Project { get; set; }
        public System.Collections.Generic.ICollection<InstitutionDisplayViewModel> Participants { get; set; }

        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> NotSelectedParticipants { get; set; }
    }
}
