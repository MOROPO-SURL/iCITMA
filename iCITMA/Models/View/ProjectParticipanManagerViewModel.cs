namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectParticipanManagerViewModel
    {
        public ProjectDisplayViewModel Project { get; set; }
        public System.Collections.Generic.ICollection<PersonDisplayViewModel> Participans { get; set; }

        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> NotSelectedParticipans { get; set; }
    }
}
