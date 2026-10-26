using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.CITMA.CMG.iCITMA.Models.View;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.CITMA.CMG.iCITMA.Security.Authorization;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("i_d_i")]
    public class ImpactIndicatorsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController <ImpactIndicator, System.Guid, ImpactIndicatorInputViewModel, ImpactIndicatorDisplayViewModel>
    {
        public ImpactIndicatorsController(IEntityRepository<ImpactIndicator, System.Guid> repository, IStringLocalizer<ImpactIndicatorsController> localizer, ILogger<ImpactIndicatorsController> logger) : base(repository, localizer, logger)
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
