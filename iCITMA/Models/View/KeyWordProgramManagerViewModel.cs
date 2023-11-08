namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class KeyWordProgramManagerViewModel
    {    
        public ProgramDisplayViewModel Program { get; set; }
        public System.Collections.Generic.ICollection<KeyWordDisplayViewModel> KeyWordss { get; set; }

        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> NotSelectedKeyWords { get; set; }
    }
}
