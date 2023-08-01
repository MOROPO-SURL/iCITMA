namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class InstitutionContactsManageViewModel
    {
        public InstitutionContactsManageViewModel() 
        { 
        } 

        public InstitutionDisplayViewModel Institution { get; set; }

        public System.Collections.Generic.List<InstitutionPhoneContactDisplayViewModel> PhoneContacts { get; set; }

        public System.Collections.Generic.List<InstitutionEmailContactDisplayViewModel> EmailContacts { get; set; }

        public System.Collections.Generic.List<InstitutionSocialContactDisplayViewModel> SocialContacts { get; set; }
        public System.Collections.Generic.List<InstitutionWebContactDisplayViewModel> WebContacts { get; set; }
        public System.Collections.Generic.List<InstitutionPostalContactDisplayViewModel> AddressContacts { get; set; }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectListItem[] SelectMunicipalities { get; set; }
        
        public Microsoft.AspNetCore.Mvc.Rendering.SelectListItem[] SelectStates { get; set; }
    }
}
