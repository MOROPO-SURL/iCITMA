using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Presentation.Web.Backend.Models.View;
using System.Collections.Generic;

namespace MOROPO.CITMA.CMG.iCITMA.Extensions
{
    public static class ManagementDashboardSectionProviderEnumerableExtensions
    {
        public static Dictionary<string, ICollection<ManagementDashboardSectionViewModel>> ToManagementDashboardSectionGroups(this IEnumerable<Framework.Guama.Core.Presentation.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> self)
        {
            var securitySections = new List<ManagementDashboardSectionViewModel>();

            foreach (var provider in self)
            {
                if (provider is Framework.Guama.Security.Personal.Presentation.Web.Backend.Providers.ManagementDashboardSectionProvider)
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
                  Title = "Tipo de Salida",
                  Controller = "OutputKinds",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.OutputKindViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Tipos de Escenario",
                  Controller = "SceneryKinds",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.SceneryKindViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Fuentes de Presupuesto",
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
                  Title = "Indicadores ODS",
                  Controller = "ODSIndicators",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.ODSIndicatorViewer
              },
               new ManagementDashboardSectionViewModel
              {
                  Title = "Personas",
                  Controller = "persons",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.PersonViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Instituciones",
                  Controller = "Institutions",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.InstitusionViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Regiones",
                  Controller = "regions",
                  Action = "index",
                  Area = "location",
                  Role = Framework.Guama.Location.Presentation.Constants.Permissions.RegionViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Provincias",
                  Controller = "states",
                  Action = "index",
                  Area = "location",
                  Role = Framework.Guama.Location.Presentation.Constants.Permissions.StateViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Municipios",
                  Controller = "municipalities",
                  Action = "index",
                  Area = "location",
                  Role = Framework.Guama.Location.Presentation.Constants.Permissions.MunicipalityViewer
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
