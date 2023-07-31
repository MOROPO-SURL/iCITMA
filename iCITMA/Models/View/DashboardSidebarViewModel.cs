using System.Collections.Generic;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class DashboardSidebarViewModel
    {
        public UserProfileViewModel UserProfile { get; set; }

        public Dictionary<string, ICollection<Framework.Guama.Core.Presentation.Web.Backend.Models.View.ManagementDashboardSectionViewModel>> ManagementDashboardSections { get; set; }
    }
}
