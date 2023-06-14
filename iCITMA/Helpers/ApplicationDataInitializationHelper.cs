using Microsoft.EntityFrameworkCore;
using System.Linq;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;
using MOROPO.Framework.Guama.Location.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Helpers
{
    public class ApplicationDataInitializationHelper : Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
    {
        private const string CUBA_COUNTRY_NAME = "Cuba";
        private const string CMG_STATE_NAME = "Camagüey";
        private const string SS_STATE_NAME = "Sancti Spíritus";

        public void InitialiseData(DbContext dbContext)
        {
            var permissionDbSet = dbContext.Set<Permission>();

            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.TraceViewer)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.TraceViewer.ToPermissionEntity());
            }

            #region ImpactIndicator
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ImpactIndicatorViewer)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ImpactIndicatorViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.ImpactIndicatorManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ImpactIndicatorCreator)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ImpactIndicatorCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.ImpactIndicatorManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ImpactIndicatorEditor)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ImpactIndicatorEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.ImpactIndicatorManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ImpactIndicatorRemover)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ImpactIndicatorRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.ImpactIndicatorManagement));
            }
            #endregion

            #region ProjectState
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ProjectStateViewer)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProjectStateViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProjectStateManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ProjectStateCreator)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProjectStateCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProjectStateManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ProjectStateEditor)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProjectStateEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProjectStateManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ProjectStateRemover)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProjectStateRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProjectStateManagement));
            }
            #endregion

            #region ResearchArea

            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ResearchAreaViewer)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ResearchAreaViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.ResearchAreaManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ResearchAreaCreator)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ResearchAreaCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.ResearchAreaManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ResearchAreaEditor)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ResearchAreaEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.ResearchAreaManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ResearchAreaRemover)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ResearchAreaRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.ResearchAreaManagement));
            }
            #endregion

            #region OutputKind

            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.OutputKindViewer)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.OutputKindViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.OutputKindManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.OutputKindCreator)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.OutputKindCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.OutputKindManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.OutputKindEditor)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.OutputKindEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.OutputKindManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.OutputKindRemover)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.OutputKindRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.OutputKindManagement));
            }
            #endregion

            #region SceneryKind

            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.SceneryKindViewer)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.SceneryKindViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.SceneryKindManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.SceneryKindCreator)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.SceneryKindCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.SceneryKindManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.SceneryKindEditor)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.SceneryKindEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.SceneryKindManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.SceneryKindRemover)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.SceneryKindRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.SceneryKindManagement));
            }
            #endregion

            #region FundingSource

            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.FundingSourceViewer)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.FundingSourceViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.FundingSourceManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.FundingSourceCreator)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.FundingSourceCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.FundingSourceManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.FundingSourceEditor)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.FundingSourceEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.FundingSourceManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.FundingSourceRemover)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.SceneryKindRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.FundingSourceManagement));
            }
            #endregion

            #region ResearcherCategory

            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ResearcherCategoryViewer)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ResearcherCategoryViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.ResearcherCategoryManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ResearcherCategoryCreator)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ResearcherCategoryCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.ResearcherCategoryManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ResearcherCategoryEditor)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ResearcherCategoryEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.ResearcherCategoryManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ResearcherCategoryRemover)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ResearcherCategoryRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.ResearcherCategoryManagement));
            }
            #endregion

            #region TeachingCategory

            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.TeachingCategoryViewer)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.TeachingCategoryViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.TeachingCategoryManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.TeachingCategoryCreator)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.TeachingCategoryCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.TeachingCategoryManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.TeachingCategoryEditor)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.TeachingCategoryEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.TeachingCategoryManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.TeachingCategoryRemover)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.TeachingCategoryRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.TeachingCategoryManagement));
            }
            #endregion

            #region ProjectCategory

            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ProjectCategoryViewer)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProjectCategoryViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProjectCategoryManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ProjectCategoryCreator)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProjectCategoryCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProjectCategoryManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ProjectCategoryEditor)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProjectCategoryEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProjectCategoryManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ProjectCategoryRemover)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProjectCategoryRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProjectCategoryManagement));
            }
            #endregion

            #region ProgramCategory

            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ProgramCategoryViewer)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProgramCategoryViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProgramCategoryManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ProgramCategoryCreator)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProgramCategoryCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProgramCategoryManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ProgramCategoryEditor)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProgramCategoryEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProgramCategoryManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ProgramCategoryRemover)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProgramCategoryRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProgramCategoryManagement));
            }
            #endregion

            #region KeyWord

            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.KeyWordViewer)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.KeyWordViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.KeyWordManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.KeyWordCreator)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.KeyWordCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.KeyWordManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.KeyWordEditor)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.KeyWordEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.KeyWordManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.KeyWordRemover)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.KeyWordRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.KeyWordManagement));
            }
            #endregion

            #region ODSIndicator
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ODSIndicatorViewer)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ODSIndicatorViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.ODSIndicatorManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ODSIndicatorCreator)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ODSIndicatorCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.ODSIndicatorManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ODSIndicatorEditor)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ODSIndicatorEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.ODSIndicatorManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.ODSIndicatorRemover)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.ODSIndicatorRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.ODSIndicatorManagement));
            }
            #endregion

            #region Institution
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.InstitusionViewer)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.InstitusionViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.InstitusionManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.InstitusionCreator)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.InstitusionCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.InstitusionManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.InstitusionEditor)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.InstitusionEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.InstitusionManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.InstitusionRemover)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.InstitusionRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.InstitusionManagement));
            }
            #endregion

            #region Person
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.PersonViewer)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.PersonViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.PersonManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.PersonCreator)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.PersonCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.PersonManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.PersonEditor)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.PersonEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.PersonManagement));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Security.Authorization.Permission.PersonRemover)))
            {
                permissionDbSet.Add(Security.Authorization.Permission.PersonRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.PersonManagement));
            }
            #endregion

            var countryDbSet = dbContext.Set<Country>();
            var stateDbSet = dbContext.Set<State>();
            var municipalitiesDbSet = dbContext.Set<Municipality>();
            var regionDbSet = dbContext.Set<Region>();
            var locationDbSet = dbContext.Set<Location>();
            var locationMuniDbSet = dbContext.Set<MunicipalityLocation>();
            var locationStateDbSet = dbContext.Set<StateLocation>();            


            if (!countryDbSet.Any(entity => entity.IsoCode.Equals(Constants.Countries.CUBA_COUNTRY_ISO_CODE)))
            {
                countryDbSet.Add(new Country { Name = "Cuba", IsoCode = Constants.Countries.CUBA_COUNTRY_ISO_CODE });
            }

            if (!stateDbSet.Any(entity => entity.Name.Equals("Camagüey")) || !stateDbSet.Any(entity => entity.Name.Equals("Sancti Spíritus")))
            {


                var country = countryDbSet.FirstOrDefault(c => c.Name == "Cuba" && c.IsoCode == Constants.Countries.CUBA_COUNTRY_ISO_CODE);
                var regionWest = new Region { Name = "Oriente", CountryId = country.Id, Country = country };
                var regionEst = new Region { Name = "Central", CountryId = country.Id, Country = country };



                regionDbSet.Add(regionWest);
                regionDbSet.Add(regionEst);

                var stateCMG = new State { Name = "Camagüey", RegionId = regionWest.Id, Region = regionWest };
                var stateSS = new State { Name = "Sancti Spíritus", RegionId = regionEst.Id, Region = regionEst };

                stateDbSet.Add(stateCMG);
                stateDbSet.Add(stateSS);
                
                var stateLocationCMG = new StateLocation { State = stateCMG, StateId = stateCMG.Id };
                var stateLocationSS = new StateLocation { State = stateSS, StateId = stateSS.Id };
                locationStateDbSet.Add(stateLocationCMG);
                locationStateDbSet.Add(stateLocationSS);



                var cmgMunicipalitiesNames = new string[] { "Camagüey", "Florida", "Guáimaro", "Vertientes", "Santa Cruz del Sur", "Nuevitas", "Minas", "Sibanicú", "Esmeralda", "Carlos M. de Cespedes", "Jimaguayú", "Sierra de Cubitas", "Najasa" };
                var ssMunicipalitiesNames = new string[] { "Sancti Spíritus", "Trinidad", "Yaguajay" };



                foreach (string municipalityName in cmgMunicipalitiesNames)
                {
                    if (municipalitiesDbSet.Any(e => e.Name.Equals(municipalityName))) continue;
                    var mun = new Municipality { Name = municipalityName, State = stateCMG, StateId = stateCMG.Id };
                    municipalitiesDbSet.Add(mun);
                    locationMuniDbSet.Add(new MunicipalityLocation { Municipality = mun, MunicipalityId = mun.Id });
                }

                foreach (string municipalityName in ssMunicipalitiesNames)
                {
                    if (municipalitiesDbSet.Any(e => e.Name.Equals(municipalityName))) continue;
                    var mun = new Municipality { Name = municipalityName, State = stateSS, StateId = stateSS.Id };
                    municipalitiesDbSet.Add(mun);
                    locationMuniDbSet.Add(new MunicipalityLocation { Municipality = mun, MunicipalityId = mun.Id });
                }
            }


            if (dbContext is Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.ITraceableDbContext)
            {
                (dbContext as Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.ITraceableDbContext).SaveChanges("system");
            }
            else
            {
                dbContext.SaveChanges();
            }
        }
    }
}
