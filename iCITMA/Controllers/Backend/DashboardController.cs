using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.CITMA.CMG.iCITMA.Extensions;
using System.Collections.Generic;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [SAPRESSC.Core.Web.Security.Attributes.RequirePermissions(SAPRESSC.Core.Security.Common.Web.Backend.Constants.Permission.ShellManager)]
    [SAPRESSC.Core.Web.Security.Attributes.ChangeUserPasswordRequiredAction]
    [SAPRESSC.Core.Web.Security.Attributes.CatchChangeUserPasswordRequiredException]
    [Route("management/[controller]")]
    [Route("{culture:regex(^[[a-z]]{{2}}(?:-[[A-Z]]{{2}})?$)}/management/[controller]")]
    public class DashboardController : SAPRESSC.Core.Web.Common.Controllers.BaseWebController
    {
        private readonly IEnumerable<SAPRESSC.Core.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> managementDashboardSectionProviders;

        public DashboardController(IEnumerable<SAPRESSC.Core.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> managementDashboardSectionProviders, Microsoft.Extensions.Localization.IStringLocalizer<DashboardController> localizer, ILogger<DashboardController> logger) : base(localizer, logger)
        {
            this.managementDashboardSectionProviders = managementDashboardSectionProviders;
        }

        public IActionResult Index()
        {
            var model = new Models.View.ManagementDashboardViewModel { Sections = managementDashboardSectionProviders.ToManagementDashboardSectionGroups() };

            return View(model);
        }
    }
}
