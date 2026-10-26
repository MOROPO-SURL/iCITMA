using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MOROPO.CITMA.CMG.iCITMA.Models.View;
using MOROPO.CITMA.CMG.iCITMA.Models.View.Filter;
using MOROPO.CITMA.CMG.iCITMA.Security.Authorization;
using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Backend.Controllers;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("Security")]
    public class TracesController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementFilteredController<Trace, long, TraceInputViewModel, TraceDisplayViewModel, TracesFilterModel>
    {
        public TracesController(IEntityRepository<Trace, long> repository, IStringLocalizer<TracesController> localizer, ILogger<TracesController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Permission.TraceViewer)]
        public IActionResult Index()   => View();        

        [RequirePermissions(Permission.TraceViewer)]
        public override IActionResult Filter(TracesFilterModel filterModel) => base.Filter(filterModel);
        

        protected override string GetFilterSessionID() => "traces-management-filter";
        

        public override IActionResult Create() => NotFound();

        public override IActionResult Create(TraceInputViewModel modelInput) => NotFound();

        public override IActionResult Edit(long key) => NotFound();

        public override IActionResult Edit(TraceInputViewModel modelInput) => NotFound();

        public override IActionResult Delete(long key) => NotFound();

        public override IActionResult Delete(TraceDisplayViewModel displayModel) => NotFound();
    }
}
