using Microsoft.AspNetCore.Mvc;
using MOROPO.CITMA.CMG.iCITMA.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.Web.Backend.Providers.Facade;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Managers.Facade;
using System.Collections.Generic;

namespace MOROPO.CITMA.CMG.iCITMA.Components
{
    public class DashboardSidebarViewComponent : ViewComponent
    {
        private readonly IEnumerable<IManagementDashboardSectionProviderFacade> managementDashboardSectionProviders;
        private readonly IUserProfileManagerFacade userProfileManager;

        public DashboardSidebarViewComponent(IUserProfileManagerFacade userProfileManager, IEnumerable<IManagementDashboardSectionProviderFacade> managementDashboardSectionProviders)
        {
            this.managementDashboardSectionProviders = managementDashboardSectionProviders;
            this.userProfileManager = userProfileManager;
        }

        public IViewComponentResult Invoke()
        {
            return View(new Models.View.DashboardSidebarViewModel
            {
                UserProfile = (Models.View.UserProfileViewModel)userProfileManager.GetUserProfile(User.Identity.Name),
                ManagementDashboardSections = managementDashboardSectionProviders.ToManagementDashboardSectionGroups()
            });
        }
    }
}
