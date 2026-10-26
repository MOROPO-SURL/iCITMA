namespace MOROPO.CITMA.CMG.iCITMA.Models.View.Contract
{
    public abstract class AbstractContactsManageViewModel
    {
        public System.Collections.Generic.List<PhoneContactDisplayViewModel> PhoneContacts { get; set; }

        public System.Collections.Generic.List<EmailContactDisplayViewModel> EmailContacts { get; set; }

        public System.Collections.Generic.List<WebContactDisplayViewModel> WebContacts { get; set; }

        public System.Collections.Generic.List<PostalContactDisplayViewModel> AddressContacts { get; set; }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectListItem[] MunicipalitySelectListItems { get; set; }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectListItem[] StateSelectListItems { get; set; }
    }
}
