using System;
using System.Collections.Generic;
using App.Common;
using App.Common.Data;
using App.Common.DI;
using App.Common.Validation;
using App.Context;
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

        public void DeletePermission(string id)
        {
            ValidateDeletePermission(id);
            using (UnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IPermissionsRepository permissionsRepository = IoC.Container.Resolve<IPermissionsRepository>(uow);
                permissionsRepository.Delete(id);
                uow.Commit();
            }

        }

        private void ValidateDeletePermission(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ValidationException("security.detetePermission.invalidId");
            }
            Guid guidId;
            if (!Guid.TryParse(id, out guidId))
            {
                throw  new ValidationException("security.detetePermission.invalidId");
            }

        }
    }
}
