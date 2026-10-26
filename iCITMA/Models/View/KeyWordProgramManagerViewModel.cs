namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class KeyWordProgramManagerViewModel: GenericKeyWordsManagerViewModel<ProgramDisplayViewModel>
    {  
        
        public System.Collections.Generic.ICollection<KeyWordDisplayViewModel> KeyWordss { get; set; }

        public System.Collections.Generic.ICollection<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> NotSelectedKeyWords { get; set; }
    }
}
