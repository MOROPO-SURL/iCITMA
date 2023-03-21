using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.CITMA.CMG.iCITMA.Models.View;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.CITMA.CMG.iCITMA.Security.Authorization;
using MOROPO.SAPRESSC.Core.Persistence.Repositories;
using MOROPO.SAPRESSC.Core.Web.Security.Attributes;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(SAPRESSC.Core.Security.Common.Web.Backend.Constants.Permission.ShellManager)]
    [Area("Auxiliares")]
    public class SceneryKindsController: SAPRESSC.Core.Web.Backend.Controllers.AbstractEntityManagementController<SceneryKind, System.Guid, SceneryKindInputViewModel, SceneryKindDisplayViewModel>
    {
        public SceneryKindsController(IEntityRepository<SceneryKind, Guid> repository, IStringLocalizer<SceneryKindsController> localizer, ILogger<SceneryKindsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Permission.SceneryKindViewer)]
        public IActionResult Index()
        {
            return View();
        }

        [RequirePermissions(Permission.SceneryKindCreator)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Permission.SceneryKindCreator)]
        public override IActionResult Create(SceneryKindInputViewModel inputViewModel)
        {
            return base.Create(inputViewModel);
        }

        [RequirePermissions(Permission.SceneryKindEditor)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Permission.SceneryKindEditor)]
        public override IActionResult Edit(SceneryKindInputViewModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Permission.SceneryKindRemover)]
        public override IActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Permission.SceneryKindRemover)]
        public override IActionResult Delete(SceneryKindDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }
    }
}