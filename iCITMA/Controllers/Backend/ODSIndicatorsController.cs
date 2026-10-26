using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.CITMA.CMG.iCITMA.Models.View;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.CITMA.CMG.iCITMA.Security.Authorization;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using System;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("Auxiliares")]
    public class ODSIndicatorsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<ODSIndicator, System.Guid, ODSIndicatorInputViewModel, ODSIndicatorDisplayViewModel>
    {
        public ODSIndicatorsController(IEntityRepository<ODSIndicator, Guid> repository, IStringLocalizer<ODSIndicatorsController> localizer, ILogger<ODSIndicatorsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Permission.ODSIndicatorViewer)]
        public IActionResult Index() => View();
        
        [RequirePermissions(Permission.ODSIndicatorCreator)]
        public override IActionResult Create() => base.Create();


        [RequirePermissions(Permission.ODSIndicatorCreator)]
        public override IActionResult Create(ODSIndicatorInputViewModel inputViewModel) => base.Create(inputViewModel);

        [RequirePermissions(Permission.ODSIndicatorEditor)]
        public override IActionResult Edit(Guid key) => base.Edit(key);

        [RequirePermissions(Permission.ODSIndicatorEditor)]
        public override IActionResult Edit(ODSIndicatorInputViewModel inputViewModel) => base.Edit(inputViewModel);

        [RequirePermissions(Permission.ODSIndicatorRemover)]
        public override IActionResult Delete(Guid key) => base.Delete(key);

        [RequirePermissions(Permission.ODSIndicatorRemover)]
        public override IActionResult Delete(ODSIndicatorDisplayViewModel displayViewModel) => base.Delete(displayViewModel);
    }
}
