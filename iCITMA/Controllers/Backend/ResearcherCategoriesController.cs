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
    public class ResearcherCategoriesController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<ResearcherCategory, System.Guid, ResearcherCategoryInputViewModel, ResearcherCategoryDisplayViewModel>
    {
        public ResearcherCategoriesController(IEntityRepository<ResearcherCategory, System.Guid> repository, IStringLocalizer<ResearcherCategoriesController> localizer, ILogger<ResearcherCategoriesController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Permission.ResearcherCategoryViewer)]
        public IActionResult Index()
        {
            return View();
        }

        [RequirePermissions(Permission.ResearcherCategoryCreator)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Permission.ResearcherCategoryCreator)]
        public override IActionResult Create(ResearcherCategoryInputViewModel inputViewModel)
        {
            return base.Create(inputViewModel);
        }

        [RequirePermissions(Permission.ResearcherCategoryEditor)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Permission.ResearcherCategoryEditor)]
        public override IActionResult Edit(ResearcherCategoryInputViewModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Permission.ResearcherCategoryRemover)]
        public override IActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Permission.ResearcherCategoryRemover)]
        public override IActionResult Delete(ResearcherCategoryDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }
    }
}
