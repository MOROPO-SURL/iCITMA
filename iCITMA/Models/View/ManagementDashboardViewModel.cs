using System.Collections.Generic;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ManagementDashboardViewModel
    {
        public Dictionary<string, ICollection<SAPRESSC.Core.Web.Backend.Models.View.ManagementDashboardSectionViewModel>> Sections { get; set; }
    }
}
