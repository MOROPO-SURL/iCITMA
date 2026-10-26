namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProgramExpertManagerViewModel
    {
        public ProgramDisplayViewModel Program { get; set; }
        public System.Collections.Generic.ICollection<PersonDisplayViewModel> Experts { get; set; }

        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> NotSelectedExperts { get; set; }
    }
}
