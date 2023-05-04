using Microsoft.AspNetCore.Mvc;

namespace MOROPO.CITMA.CMG.iCITMA.Managers
{
    public class UserProfileManager : Framework.Guama.Core.Presentation.Web.Security.Managers.Facade.IUserProfileManagerFacade
    {
        public Framework.Guama.Core.Presentation.Web.Security.Models.View.Contrat.IUserProfileViewModel GetUserProfile(string username)
        {
            return new Models.View.UserProfileViewModel();
        }

        public void PreValidateUserProfile(string username, Framework.Guama.Core.Presentation.Web.Security.Models.View.Contrat.IUserProfileViewModel profileModel, Controller controller)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUserProfile(string username, Framework.Guama.Core.Presentation.Web.Security.Models.View.Contrat.IUserProfileViewModel profileModel)
        {
        }
    }
}
