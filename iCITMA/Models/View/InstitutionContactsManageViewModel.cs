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
    }
}
