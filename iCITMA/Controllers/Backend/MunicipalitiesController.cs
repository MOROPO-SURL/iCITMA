using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.SAPRESSC.Core.Persistence.Repositories;
using MOROPO.SAPRESSC.Core.Web.Security.Attributes;
using MOROPO.SAPRESSC.Middleware.Region.Persistence.Entities;
using System;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(SAPRESSC.Core.Security.Common.Web.Backend.Constants.Permission.ShellManager)]
    [Area("Auxiliares")]
    public class MunicipalitiesController : MOROPO.SAPRESSC.Middleware.Region.Web.Backend.Controllers.MunicipalitiesController
    {

        public MunicipalitiesController(IEntityRepository<State, Guid> stateRepository, IEntityRepository<Municipality, Guid> repository, IStringLocalizer<SAPRESSC.Middleware.Region.Web.Backend.Controllers.MunicipalitiesController> localizer, ILogger<SAPRESSC.Middleware.Region.Web.Backend.Controllers.MunicipalitiesController> logger) : base(stateRepository, repository, localizer, logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
