using Microsoft.EntityFrameworkCore;
using MOROPO.SAPRESSC.Core.Security.Common.Persistence.Entities;
using MOROPO.SAPRESSC.Core.Security.Common.Persistence.EF.Extensions;
using MOROPO.SAPRESSC.Middleware.Region.Persistence.Entities;
using System.Linq;
using MOROPO.CITMA.CMG.iCITMA.RegionConst;

namespace MOROPO.CITMA.CMG.iCITMA.Helpers
{
    public class ApplicationDataInitializationHelper : SAPRESSC.Core.Persistence.EF.Helpers.Facade.IDataInitializationHelper
    {
        private const string CUBA_COUNTRY_NAME = "Cuba";
        public void InitialiseData(DbContext dbContext)
        {
            var permissionDbSet = dbContext.Set<Permission>();

            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.TraceViewer)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.TraceViewer.ToPermissionEntity());
            }

            #region ImpactIndicator
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ImpactIndicatorViewer)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ImpactIndicatorViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.ImpactIndicatorManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ImpactIndicatorCreator)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ImpactIndicatorCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.ImpactIndicatorManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ImpactIndicatorEditor)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ImpactIndicatorEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.ImpactIndicatorManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ImpactIndicatorRemover)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ImpactIndicatorRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.ImpactIndicatorManagement));
            }
            #endregion

            #region ProjectState
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ProjectStateViewer)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProjectStateViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProjectStateManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ProjectStateCreator)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProjectStateCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProjectStateManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ProjectStateEditor)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProjectStateEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProjectStateManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ProjectStateRemover)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProjectStateRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProjectStateManagement));
            }
            #endregion

            #region ResearchArea

            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ResearchAreaViewer)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ResearchAreaViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.ResearchAreaManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ResearchAreaCreator)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ResearchAreaCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.ResearchAreaManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ResearchAreaEditor)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ResearchAreaEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.ResearchAreaManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ResearchAreaRemover)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ResearchAreaRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.ResearchAreaManagement));
            }
            #endregion

            #region OutputKind

            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.OutputKindViewer)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.OutputKindViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.OutputKindManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.OutputKindCreator)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.OutputKindCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.OutputKindManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.OutputKindEditor)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.OutputKindEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.OutputKindManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.OutputKindRemover)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.OutputKindRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.OutputKindManagement));
            }
            #endregion

            #region SceneryKind

            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.SceneryKindViewer)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.SceneryKindViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.SceneryKindManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.SceneryKindCreator)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.SceneryKindCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.SceneryKindManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.SceneryKindEditor)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.SceneryKindEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.SceneryKindManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.SceneryKindRemover)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.SceneryKindRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.SceneryKindManagement));
            }
            #endregion

            #region FundingSource

            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.FundingSourceViewer)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.FundingSourceViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.FundingSourceManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.FundingSourceCreator)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.FundingSourceCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.FundingSourceManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.FundingSourceEditor)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.FundingSourceEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.FundingSourceManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.FundingSourceRemover)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.SceneryKindRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.FundingSourceManagement));
            }
            #endregion

            #region ResearcherCategory

            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ResearcherCategoryViewer)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ResearcherCategoryViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.ResearcherCategoryManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ResearcherCategoryCreator)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ResearcherCategoryCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.ResearcherCategoryManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ResearcherCategoryEditor)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ResearcherCategoryEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.ResearcherCategoryManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ResearcherCategoryRemover)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ResearcherCategoryRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.ResearcherCategoryManagement));
            }
            #endregion

            #region TeachingCategory

            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.TeachingCategoryViewer)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.TeachingCategoryViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.TeachingCategoryManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.TeachingCategoryCreator)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.TeachingCategoryCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.TeachingCategoryManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.TeachingCategoryEditor)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.TeachingCategoryEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.TeachingCategoryManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.TeachingCategoryRemover)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.TeachingCategoryRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.TeachingCategoryManagement));
            }
            #endregion

            #region ProjectCategory

            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ProjectCategoryViewer)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProjectCategoryViewer.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProjectCategoryManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ProjectCategoryCreator)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProjectCategoryCreator.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProjectCategoryManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ProjectCategoryEditor)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProjectCategoryEditor.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProjectCategoryManagement));
            }
            if (!permissionDbSet.AnyAsync(role => role.Code.Equals(Security.Authorization.Permission.ProjectCategoryRemover)).Result)
            {
                permissionDbSet.Add(Security.Authorization.Permission.ProjectCategoryRemover.ToPermissionEntity(Security.Authorization.PermissionsFamily.ProjectCategoryManagement));
            }
            #endregion

            var countryDbSet = dbContext.Set<Country>();

            var country = countryDbSet.FirstOrDefault(e => e.Name.Equals(CUBA_COUNTRY_NAME));

            if (country == null)
            {
                country = new Country { Name = CUBA_COUNTRY_NAME, IsoCode = "cu", Id = RegionInitConstant.MY_COUNTRY };

                countryDbSet.Add(country);
            }

            dbContext.SaveChanges();
        }
    }
}
