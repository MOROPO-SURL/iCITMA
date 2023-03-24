using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.CITMA.CMG.iCITMA.RegionConst;
using MOROPO.SAPRESSC.Core.Persistence.Repositories;
using MOROPO.SAPRESSC.Core.Web.Security.Attributes;
using MOROPO.SAPRESSC.Middleware.Region.Persistence.EF.Repositories;
using MOROPO.SAPRESSC.Middleware.Region.Persistence.Entities;
using MOROPO.SAPRESSC.Middleware.Region.Web.Backend.Models.View;
using System;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(SAPRESSC.Core.Security.Common.Web.Backend.Constants.Permission.ShellManager)]
    [Area("Auxiliares")]
    public class StatesController : MOROPO.SAPRESSC.Middleware.Region.Web.Backend.Controllers.StatesController
    {
        private readonly IEntityRepository<Country, System.Guid> countryRepository;

        public StatesController(IEntityRepository<Country, Guid> countryRepository, IEntityRepository<State, Guid> repository, IStringLocalizer<SAPRESSC.Middleware.Region.Web.Backend.Controllers.StatesController> localizer, ILogger<SAPRESSC.Middleware.Region.Web.Backend.Controllers.StatesController> logger) : base(countryRepository, repository, localizer, logger)
        {
            this.countryRepository = countryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
