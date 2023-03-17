using Microsoft.AspNetCore.Mvc;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.SAPRESSC.Core.Common.Models.View;
using MOROPO.SAPRESSC.Core.Web.Security.Attributes;
using MOROPO.SAPRESSC.Core.Persistence.Entities;
using MOROPO.SAPRESSC.Core.Web.Frontend;
using MOROPO.CITMA.CMG.iCITMA.Models.View;
using MOROPO.SAPRESSC.Core.Persistence.Repositories;
using System;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.SAPRESSC.Core.Web.Frontend.Controllers;
using MOROPO.CITMA.CMG.iCITMA.Security.Authorization;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(SAPRESSC.Core.Security.Common.Web.Backend.Constants.Permission.ShellManager)]
    [Area("Auxiliares")]
    public class ImpactIndicatorsController : SAPRESSC.Core.Web.Backend.Controllers.AbstractEntityManagementController <ImpactIndicator, System.Guid, ImpactIndicatorInputViewModel, ImpactIndicatorDisplayViewModel>
    {
        public ImpactIndicatorsController(IEntityRepository<ImpactIndicator, Guid> repository, IStringLocalizer<ImpactIndicatorsController> localizer, ILogger<ImpactIndicatorsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Permission.ImpactIndicatorViewer)]
        public IActionResult Index()
        {
            return View();
        }

        [RequirePermissions(Permission.ImpactIndicatorCreator)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Permission.ImpactIndicatorCreator)]
        public override IActionResult Create(ImpactIndicatorInputViewModel inputViewModel)
        {
            return base.Create(inputViewModel);
        }

        [RequirePermissions(Permission.ImpactIndicatorEditor)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Permission.ImpactIndicatorEditor)]
        public override IActionResult Edit(ImpactIndicatorInputViewModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Permission.ImpactIndicatorRemover)]
        public override IActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Permission.ImpactIndicatorRemover)]
        public override IActionResult Delete(ImpactIndicatorDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }
    }
}
