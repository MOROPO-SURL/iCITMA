using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.CITMA.CMG.iCITMA.Extensions;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Security.Personal.Persistence.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.ChangeUserPasswordRequiredAction]
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.CatchChangeUserPasswordRequiredException]
    [Route("management/[controller]")]
    [Route("{culture:regex(^[[a-z]]{{2}}(?:-[[A-Z]]{{2}})?$)}/management/[controller]")]
    public class DashboardController : Framework.Guama.Core.Presentation.Web.Common.Controllers.BaseWebController
    {
        private static readonly string[] DAYS_OF_WEEK = new[] { "Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado" };

        private readonly IEnumerable<Framework.Guama.Core.Presentation.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> managementDashboardSectionProviders;
        private readonly IEntityRepository<User, string> userRepository;
        private readonly IEntityRepository<Trace, long> traceRepository;
        private readonly IEntityRepository<Institution, System.Guid> institutionRepository;
        private readonly IEntityRepository<Person, System.Guid> personRepository;
        private readonly IEntityRepository<Persistence.Entities.Program, System.Guid> programRepository;
        private readonly IEntityRepository<Project, System.Guid> projectRepository;

        public DashboardController(IEntityRepository<Project, System.Guid> projectRepository, IEntityRepository<Persistence.Entities.Program, System.Guid> programRepository, IEntityRepository<Person, System.Guid> personRepository, IEntityRepository<Institution, System.Guid> institutionRepository, IEntityRepository<Trace, long> traceRepository, IEntityRepository<User, string> userRepository, IEnumerable<Framework.Guama.Core.Presentation.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> managementDashboardSectionProviders, Microsoft.Extensions.Localization.IStringLocalizer<DashboardController> localizer, ILogger<DashboardController> logger) : base(localizer, logger)
        {
            this.managementDashboardSectionProviders = managementDashboardSectionProviders;

            this.userRepository = userRepository;
            this.traceRepository = traceRepository;
            this.institutionRepository = institutionRepository;
            this.personRepository = personRepository;
            this.programRepository = programRepository;
            this.projectRepository = projectRepository;
        }

        public IActionResult Index()
        {
            var model = new Models.View.ManagementDashboardViewModel 
            { 
                Sections = managementDashboardSectionProviders.ToManagementDashboardSectionGroups(),
                InstitutionCount = institutionRepository.Count(),
                PersonCount = personRepository.Count(),
                ProgramCount = programRepository.Count(),
                ProjectCount = projectRepository.Count(),
                UserTotalCount = userRepository.Count(),
                UserDisabledCount = userRepository.Count(entity => !entity.Enabled),
                TraceTotalCount = traceRepository.Count(),
                TraceWeekCount = traceRepository.Count(),
                UserActivityMap = new Dictionary<string, long>(),
                WeekTracesMap = new Dictionary<string, int>()
            };

            var traces = traceRepository.GetAll().ToArray();

            foreach (var trace in traces)
            {
                if (!model.UserActivityMap.ContainsKey(trace.Author))
                {
                    model.UserActivityMap.Add(trace.Author, 1);
                }
                else
                {
                    model.UserActivityMap[trace.Author]++;
                }
            }

            var startEdgeDate = System.DateTime.Today;
            var passWeekEdgeDate = startEdgeDate.AddDays(-6);

            for (System.DateTime currentDate = passWeekEdgeDate; currentDate <= startEdgeDate; currentDate = currentDate.AddDays(1))
            {
                model.WeekTracesMap.Add(DAYS_OF_WEEK[(int)currentDate.DayOfWeek], traceRepository.Count(entity => entity.Registered.Date == currentDate));
            }

            return View(model);
        }
    }
}
