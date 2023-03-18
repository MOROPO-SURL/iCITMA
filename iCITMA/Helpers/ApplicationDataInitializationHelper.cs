using Microsoft.EntityFrameworkCore;
using MOROPO.SAPRESSC.Core.Security.Common.Persistence.Entities;
using MOROPO.SAPRESSC.Core.Security.Common.Persistence.EF.Extensions;

namespace MOROPO.CITMA.CMG.iCITMA.Helpers
{
    public class ApplicationDataInitializationHelper : SAPRESSC.Core.Persistence.EF.Helpers.Facade.IDataInitializationHelper
    {
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
        }
    }
}
