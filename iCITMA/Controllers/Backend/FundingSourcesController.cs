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
    [Area("Auxiliares")]
    public class FundingSourcesController : SAPRESSC.Core.Web.Backend.Controllers.AbstractEntityManagementController<FundingSource, System.Guid, FundingSourceInputViewModel, FundingSourceDisplayViewModel>
    {
        public FundingSourcesController(IEntityRepository<FundingSource, Guid> repository, IStringLocalizer<FundingSourcesController> localizer, ILogger<FundingSourcesController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Permission.FundingSourceViewer)]
        public IActionResult Index()
        {
            return View();
        }

        [RequirePermissions(Permission.FundingSourceCreator)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Permission.FundingSourceCreator)]
        public override IActionResult Create(FundingSourceInputViewModel inputViewModel)
        {
            return base.Create(inputViewModel);
        }

        [RequirePermissions(Permission.FundingSourceEditor)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Permission.FundingSourceEditor)]
        public override IActionResult Edit(FundingSourceInputViewModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Permission.FundingSourceRemover)]
        public override IActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Permission.FundingSourceRemover)]
        public override IActionResult Delete(FundingSourceDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }
    }
}