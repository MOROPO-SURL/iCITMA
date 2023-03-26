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
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Gestión de Tipo de Salida",
                  Controller = "OutputKinds",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.OutputKindViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Gestión de Tipos de Escenario",
                  Controller = "SceneryKinds",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.SceneryKindViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Gestión de Fuentes de Presupuesto",
                  Controller = "FundingSources",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.FundingSourceViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Categorías de Investigador",
                  Controller = "researchercategories",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.ResearcherCategoryViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Categorías Docentes",
                  Controller = "teachingcategories",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.TeachingCategoryViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Categorías de Proyectos",
                  Controller = "projectcategories",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.ProjectCategoryViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Categorías de Programa",
                  Controller = "programcategories",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.ProgramCategoryViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Palabras Claves",
                  Controller = "keywords",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.KeyWordViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Provincias",
                  Controller = "states",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = SAPRESSC.Middleware.Region.Security.Constants.Roles.StateViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Municipios",
                  Controller = "municipalities",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = SAPRESSC.Middleware.Region.Security.Constants.Roles.MunicipalityViewer
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
