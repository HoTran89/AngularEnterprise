using System.Collections.Generic;
using App.Common.DI;
using App.Repository.Security;
using App.Service.Security;

namespace App.Service.Impl.Security
{
    public class PermissionsService : IPermissionService
    {
        public IList<PermissionListItem> GetPermissons()
        {
            IPermissionsRepository permissionsRepository = IoC.Container.Resolve<IPermissionsRepository>();
            return permissionsRepository.GetItems<PermissionListItem>();
        }
    }
}
