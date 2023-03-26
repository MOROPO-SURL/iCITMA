using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.CITMA.CMG.iCITMA.Models.View;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.CITMA.CMG.iCITMA.Security.Authorization;
using MOROPO.SAPRESSC.Core.Persistence.Repositories;
using MOROPO.SAPRESSC.Core.Web.Security.Attributes;
using System;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(SAPRESSC.Core.Security.Common.Web.Backend.Constants.Permission.ShellManager)]
    [Area("Auxiliares")]
    public class ProgramCategoriesController : SAPRESSC.Core.Web.Backend.Controllers.AbstractEntityManagementController<ProgramCategory, System.Guid, ProgramCategoryInputViewModel, ProgramCategoryDisplayViewModel>
    {
        public ProgramCategoriesController(IEntityRepository<ProgramCategory, Guid> repository, IStringLocalizer<ProgramCategoriesController> localizer, ILogger<ProgramCategoriesController> logger) : base(repository, localizer, logger)
        {
        }
        [RequirePermissions(Permission.ProgramCategoryViewer)]
        public IActionResult Index()
        {
            return View();
        }

        [RequirePermissions(Permission.ProgramCategoryCreator)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Permission.ProgramCategoryCreator)]
        public override IActionResult Create(ProgramCategoryInputViewModel inputViewModel)
        {
            return base.Create(inputViewModel);
        }

        [RequirePermissions(Permission.ProgramCategoryEditor)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Permission.ProgramCategoryEditor)]
        public override IActionResult Edit(ProgramCategoryInputViewModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Permission.ProgramCategoryRemover)]
        public override IActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Permission.ProgramCategoryRemover)]
        public override IActionResult Delete(ProgramCategoryDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }
    }
}

