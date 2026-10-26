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
    [Area("ecosystem")]
    public class TeachingCategoriesController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<TeachingCategory, System.Guid, TeachingCategoryInputViewModel, TeachingCategoryDisplayViewModel>
    {
        public TeachingCategoriesController(IEntityRepository<TeachingCategory, System.Guid> repository, IStringLocalizer<TeachingCategoriesController> localizer, ILogger<TeachingCategoriesController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Permission.TeachingCategoryViewer)]
        public IActionResult Index()
        {
            return View();
        }

        [RequirePermissions(Permission.TeachingCategoryCreator)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Permission.TeachingCategoryCreator)]
        public override IActionResult Create(TeachingCategoryInputViewModel inputViewModel)
        {
            return base.Create(inputViewModel);
        }

        [RequirePermissions(Permission.TeachingCategoryEditor)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Permission.TeachingCategoryEditor)]
        public override IActionResult Edit(TeachingCategoryInputViewModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Permission.TeachingCategoryRemover)]
        public override IActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Permission.TeachingCategoryRemover)]
        public override IActionResult Delete(TeachingCategoryDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }
    }
}
