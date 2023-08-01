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

            securitySections.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Registros",
                Controller = "traces",
                Action = "index",
                Area = "security",
                Role = Security.Authorization.Permission.TraceViewer
            });

            var ecosistemaSections = new List<ManagementDashboardSectionViewModel>
            {
                  new ManagementDashboardSectionViewModel
                  {
                      Title = "Instituciones",
                      Controller = "institutions",
                      Action = "index",
                      Area = "ecosystem",
                      Role = Security.Authorization.Permission.InstitusionViewer
                  },
                  new ManagementDashboardSectionViewModel
                  {
                      Title = "Personas",
                      Controller = "persons",
                      Action = "index",
                      Area = "ecosystem",
                      Role = Security.Authorization.Permission.PersonViewer
                  },
                  new ManagementDashboardSectionViewModel
                  {
                      Title = "Categorías de Investigador",
                      Controller = "researchercategories",
                      Action = "index",
                      Area = "ecosystem",
                      Role = Security.Authorization.Permission.ResearcherCategoryViewer
                  },
                  new ManagementDashboardSectionViewModel
                  {
                      Title = "Categorías Docentes",
                      Controller = "teachingcategories",
                      Action = "index",
                      Area = "ecosystem",
                      Role = Security.Authorization.Permission.TeachingCategoryViewer
                  }
            };

            var iDiSections = new List<ManagementDashboardSectionViewModel>
            {
              new ManagementDashboardSectionViewModel
              {
                  Title = "Programas",
                  Controller = "programs",
                  Action = "index",
                  Area = "i_d_i",
                  Role = Security.Authorization.Permission.ProgramViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Proyectos",
                  Controller = "projects",
                  Action = "index",
                  Area = "i_d_i",
                  Role = Security.Authorization.Permission.ProjectViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Estados de Proyecto",
                  Controller = "projectstates",
                  Action = "index",
                  Area = "i_d_i",
                  Role = Security.Authorization.Permission.ProjectStateViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Categorías de Programa",
                  Controller = "programcategories",
                  Action = "index",
                  Area = "i_d_i",
                  Role = Security.Authorization.Permission.ProgramCategoryViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Categorías de Proyectos",
                  Controller = "projectcategories",
                  Action = "index",
                  Area = "i_d_i",
                  Role = Security.Authorization.Permission.ProjectCategoryViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Indicadores de Impacto",
                  Controller = "impactindicators",
                  Action = "index",
                  Area = "i_d_i",
                  Role = Security.Authorization.Permission.ImpactIndicatorViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Areas de Investigación",
                  Controller = "researchareas",
                  Action = "index",
                  Area = "i_d_i",
                  Role = Security.Authorization.Permission.ResearchAreaViewer
              }
            };

            var auxiliaresSections = new List<ManagementDashboardSectionViewModel>
            {
              new ManagementDashboardSectionViewModel
              {
                  Title = "Tipos de Salida",
                  Controller = "outputkinds",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.OutputKindViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Tipos de Escenario",
                  Controller = "scenerykinds",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.SceneryKindViewer
              },
              new ManagementDashboardSectionViewModel
              {
                  Title = "Fuentes de Presupuesto",
                  Controller = "fundingsources",
                  Action = "index",
                  Area = "Auxiliares",
                  Role = Security.Authorization.Permission.FundingSourceViewer
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
                { "Ecosistema", ecosistemaSections },
                { "I + D + i", iDiSections },
                { "Auxiliares", auxiliaresSections },
            };
        }
    }
}
