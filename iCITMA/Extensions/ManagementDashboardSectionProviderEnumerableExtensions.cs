using MOROPO.SAPRESSC.Core.Web.Backend.Models.View;
using System.Collections.Generic;

namespace MOROPO.CITMA.CMG.iCITMA.Extensions
{
    public static class ManagementDashboardSectionProviderEnumerableExtensions
    {
        public static Dictionary<string, ICollection<ManagementDashboardSectionViewModel>> ToManagementDashboardSectionGroups(this IEnumerable<SAPRESSC.Core.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> self)
        {
            var securitySections = new List<ManagementDashboardSectionViewModel>();

            foreach (var provider in self)
            {
                if (provider is SAPRESSC.Middleware.Security.Identity.Web.Backend.Providers.ManagementDashboardSectionProvider)
                {
                    securitySections.AddRange(provider.GetManagementDashboardSections());
                }
            }

            var auxiliaresSections = new List<ManagementDashboardSectionViewModel>
            {
              new ManagementDashboardSectionViewModel
              {
                  Title = "Indicador de Impacto",
                  Controller = "ImpactIndicators",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.ImpactIndicatorViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Estados de Proyecto",
                  Controller = "ProjectStates",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.ProjectStateViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Areas de Investigación",
                  Controller = "ResearchAreas",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.ResearchAreaViewer
              }
            };

            return new Dictionary<string, ICollection<ManagementDashboardSectionViewModel>>
            {
                { "Seguridad", securitySections },
                { "Auxiliares", auxiliaresSections },
            };
        }
    }
}
