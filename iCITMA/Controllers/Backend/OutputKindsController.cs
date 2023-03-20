using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.CITMA.CMG.iCITMA.Models.View;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.CITMA.CMG.iCITMA.Security.Authorization;
using MOROPO.SAPRESSC.Core.Persistence.Repositories;
using MOROPO.SAPRESSC.Core.Web.Frontend.Controllers;
using MOROPO.SAPRESSC.Core.Web.Security.Attributes;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(SAPRESSC.Core.Security.Common.Web.Backend.Constants.Permission.ShellManager)]
    [Microsoft.AspNetCore.Mvc.Area("Auxiliares")]
    public class OutputKindsController : SAPRESSC.Core.Web.Backend.Controllers.AbstractEntityManagementController<OutputKind, System.Guid, OutputKindInputViewModel, OutputKindDisplayViewModel>
    {
        public OutputKindsController(IEntityRepository<OutputKind, Guid> repository, IStringLocalizer<OutputKindsController> localizer, ILogger<OutputKindsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Permission.OutputKindViewer)]
        public IActionResult Index()
        {
            return View();
        }

        [RequirePermissions(Permission.OutputKindCreator)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Permission.OutputKindCreator)]
        public override IActionResult Create(OutputKindInputViewModel inputViewModel)
        {
            return base.Create(inputViewModel);
        }

        [RequirePermissions(Permission.OutputKindEditor)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Permission.OutputKindEditor)]
        public override IActionResult Edit(OutputKindInputViewModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Permission.OutputKindRemover)]
        public override IActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Permission.OutputKindRemover)]
        public override IActionResult Delete(OutputKindDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }
    }
}