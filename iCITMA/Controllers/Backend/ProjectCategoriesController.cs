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
    public class ProjectCategoriesController : SAPRESSC.Core.Web.Backend.Controllers.AbstractEntityManagementController<ProjectCategory, System.Guid, ProjectCategoryInputViewModel, ProjectCategoryDisplayViewModel>
    {
        public ProjectCategoriesController(IEntityRepository<ProjectCategory, Guid> repository, IStringLocalizer<ProjectCategoriesController> localizer, ILogger<ProjectCategoriesController> logger) : base(repository, localizer, logger)
        {
        }
        [RequirePermissions(Permission.ProjectCategoryViewer)]
        public IActionResult Index()
        {
            return View();
        }

        [RequirePermissions(Permission.ProjectCategoryCreator)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Permission.ProjectCategoryCreator)]
        public override IActionResult Create(ProjectCategoryInputViewModel inputViewModel)
        {
            return base.Create(inputViewModel);
        }

        [RequirePermissions(Permission.ProjectCategoryEditor)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Permission.ProjectCategoryEditor)]
        public override IActionResult Edit(ProjectCategoryInputViewModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Permission.ProjectCategoryRemover)]
        public override IActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Permission.ProjectCategoryRemover)]
        public override IActionResult Delete(ProjectCategoryDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }
    }
}
