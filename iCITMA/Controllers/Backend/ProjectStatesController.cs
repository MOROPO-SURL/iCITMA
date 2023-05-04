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
    [Area("Auxiliares")]
    public class ProjectStatesController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<ProjectState, System.Guid, ProjectStateInputViewModel, ProjectStateDisplayViewModel>
    {
        public ProjectStatesController(IEntityRepository<ProjectState, System.Guid> repository, IStringLocalizer<ProjectStatesController> localizer, ILogger<ProjectStatesController> logger) : base(repository, localizer, logger)
        {
        }        

        [RequirePermissions(Permission.ProjectStateViewer)]
        public IActionResult Index()
        {
            return View();
        }

        [RequirePermissions(Permission.ProjectStateCreator)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Permission.ProjectStateCreator)]
        public override IActionResult Create(ProjectStateInputViewModel inputViewModel)
        {
            return base.Create(inputViewModel);
        }

        [RequirePermissions(Permission.ProjectStateEditor)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Permission.ProjectStateEditor)]
        public override IActionResult Edit(ProjectStateInputViewModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Permission.ProjectStateRemover)]
        public override IActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Permission.ProjectStateRemover)]
        public override IActionResult Delete(ProjectStateDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }
    }
}
