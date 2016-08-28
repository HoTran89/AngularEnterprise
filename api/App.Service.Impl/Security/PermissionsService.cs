using System;
using System.Collections.Generic;
using App.Common;
using App.Common.Data;
using App.Common.DI;
using App.Common.Validation;
using App.Context;
using App.Entity.Security;
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
                throw new ValidationException("security.detetePermission.invalidId");
            }

        }
        public void AddPermission(AddPermissionRequest request)
        {
            ValidationAddPermission(request);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IPermissionsRepository permissionsRepository = IoC.Container.Resolve<IPermissionsRepository>(uow);
                Permission permission = new Permission(request.Name, request.Key, request.Description);
                permissionsRepository.Add(permission);
                uow.Commit();
            }
        }

        public PermissionListItem GetPermissonById(string id)
        {
            ValidattionGetPermissionById(id);
            IPermissionsRepository permissionsRepository = IoC.Container.Resolve<IPermissionsRepository>();
            return permissionsRepository.GetById<PermissionListItem>(id);
        }

        public void Updatepermission(AddPermissionRequest request, string id)
        {
            ValidationUpdatePermission(request, id);
            using (IUnitOfWork uow = new UnitOfWork(new AppDbContext(IOMode.Write)))
            {
                IPermissionsRepository permissionsRepository = IoC.Container.Resolve<IPermissionsRepository>(uow);
                Permission permission = permissionsRepository.GetById(id);
                if (permission != null)
                {
                    permission.Name = request.Name;
                    permission.Key = request.Key;
                    permission.Description = request.Description;
                    uow.Commit();
                }

            }
        }

        private void ValidationUpdatePermission(AddPermissionRequest request, string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ValidationException("security.detetePermission.invalidId");
            }
            Guid guidId;
            if (!Guid.TryParse(id, out guidId))
            {
                throw new ValidationException("security.detetePermission.invalidId");
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("security.addPermission.nameIsRequired");
            }
            if (string.IsNullOrWhiteSpace(request.Key))
            {
                throw new ValidationException("security.addPermission.keyIsRequired");
            }
            if (request.Key.Contains(" "))
            {
                throw new ValidationException("security.addPermission.keyHasNotWhiteSpace");
            }
        }

        private void ValidattionGetPermissionById(string id)
        {
        }

        private void ValidationAddPermission(AddPermissionRequest permissionRequest)
        {
            if (string.IsNullOrWhiteSpace(permissionRequest.Name))
            {
                throw new ValidationException("security.addPermission.nameIsRequired");
            }
            if (string.IsNullOrWhiteSpace(permissionRequest.Key))
            {
                throw new ValidationException("security.addPermission.keyIsRequired");
            }
            if (permissionRequest.Key.Contains(" "))
            {
                throw new ValidationException("security.addPermission.keyHasNotWhiteSpace");
            }
        }
    }
}
