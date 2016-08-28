using System.Collections.Generic;

namespace App.Service.Security
{
    public interface IPermissionService
    {
        IList<PermissionListItem> GetPermissons();
        void DeletePermission(string id);
        void AddPermission(AddPermissionRequest request);
        PermissionListItem GetPermissonById(string id);
        void Updatepermission(AddPermissionRequest request, string id);
    }
}
