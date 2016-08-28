using System.Collections.Generic;

namespace App.Service.Security
{
    public interface IPermissionService
    {
        IList<PermissionListItem> GetPermissons();
        void DeletePermission(string id);
    }
}
