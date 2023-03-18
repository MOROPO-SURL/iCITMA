using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.CITMA.CMG.iCITMA.Models.View;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.CITMA.CMG.iCITMA.Security.Authorization;
using MOROPO.SAPRESSC.Core.Persistence.Repositories;
using MOROPO.SAPRESSC.Core.Web.Frontend.Controllers;
using MOROPO.SAPRESSC.Core.Web.Security.Attributes;
using System;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(SAPRESSC.Core.Security.Common.Web.Backend.Constants.Permission.ShellManager)]
    [Area("Auxiliares")]
    public class ResearchAreasController : SAPRESSC.Core.Web.Backend.Controllers.AbstractEntityManagementController<ResearchArea, System.Guid, ResearchAreaInputViewModel, ResearchAreaDisplayViewModel>
    {
        public ResearchAreasController(IEntityRepository<ResearchArea, Guid> repository, IStringLocalizer<ResearchAreasController> localizer, ILogger<ResearchAreasController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Permission.ResearchAreaViewer)]
        public IActionResult Index()
        {
            return View();
        }

        [RequirePermissions(Permission.ResearchAreaCreator)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Permission.ResearchAreaCreator)]
        public override IActionResult Create(ResearchAreaInputViewModel inputViewModel)
        {
            return base.Create(inputViewModel);
        }

        [RequirePermissions(Permission.ResearchAreaEditor)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Permission.ResearchAreaEditor)]
        public override IActionResult Edit(ResearchAreaInputViewModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Permission.ResearchAreaRemover)]
        public override IActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Permission.ResearchAreaRemover)]
        public override IActionResult Delete(ResearchAreaDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }
    }
}