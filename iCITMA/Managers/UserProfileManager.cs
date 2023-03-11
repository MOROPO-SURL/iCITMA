using Microsoft.AspNetCore.Mvc;

namespace MOROPO.CITMA.CMG.iCITMA.Managers
{
    public class UserProfileManager : SAPRESSC.Core.Web.Security.Managers.Facade.IUserProfileManagerFacade
    {
        public SAPRESSC.Core.Web.Security.Models.View.Contrat.IUserProfileViewModel GetUserProfile(string username)
        {
            return new Models.View.UserProfileViewModel();
        }

        public void PreValidateUserProfile(string username, SAPRESSC.Core.Web.Security.Models.View.Contrat.IUserProfileViewModel profileModel, Controller controller)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUserProfile(string username, SAPRESSC.Core.Web.Security.Models.View.Contrat.IUserProfileViewModel profileModel)
        {
        }
    }
}
