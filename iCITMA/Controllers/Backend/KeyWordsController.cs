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
    public class KeyWordsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<KeyWord, System.Guid, KeyWordInputViewModel, KeyWordDisplayViewModel>
    {
        public KeyWordsController(IEntityRepository<KeyWord, System.Guid> repository, IStringLocalizer<KeyWordsController> localizer, ILogger<KeyWordsController> logger) : base(repository, localizer, logger)
        {
        }
        [RequirePermissions(Permission.KeyWordViewer)]
        public IActionResult Index()
        {
            return View();
        }

        [RequirePermissions(Permission.KeyWordCreator)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Permission.KeyWordCreator)]
        public override IActionResult Create(KeyWordInputViewModel inputViewModel)
        {
            return base.Create(inputViewModel);
        }

        [RequirePermissions(Permission.KeyWordEditor)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Permission.KeyWordEditor)]
        public override IActionResult Edit(KeyWordInputViewModel inputModel)
        {
            return base.Edit(inputModel);
        }

        [RequirePermissions(Permission.KeyWordRemover)]
        public override IActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        [RequirePermissions(Permission.KeyWordRemover)]
        public override IActionResult Delete(KeyWordDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }
    }
}

