using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using App.Common.DI;
using App.Common.Http;
using App.Common.Validation;
using App.Service.Impl.Security;
using App.Service.Security;

namespace App.Api.Features.Security
{
    [RoutePrefix("api/permissions")]
    public class PermissionsController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IResponseData<IList<PermissionListItem>> GetPermissions()
        {
            IResponseData<IList<PermissionListItem>> responseData = new ResponseData<IList<PermissionListItem>>();
            try
            {
                IPermissionService permissionsService = IoC.Container.Resolve<IPermissionService>();
                IList<PermissionListItem> items = permissionsService.GetPermissons();
                responseData.SetData(items);
            }
            catch (ValidationException exception)
            {
                responseData.SetErrors(exception.Errors);
                responseData.SetStatus(HttpStatusCode.PreconditionFailed);
            }
            return responseData;
        }

        [Route("{id}")]
        [HttpGet]
        public IResponseData<PermissionListItem> GetPermission([FromUri]string id)
        {
            IResponseData<PermissionListItem> responseData = new ResponseData<PermissionListItem>();
            try
            {
                IPermissionService permissionService = IoC.Container.Resolve<IPermissionService>();
                PermissionListItem item = permissionService.GetPermissonById(id);
                responseData.SetData(item);
            }
            catch (ValidationException exception)
            {
                responseData.SetErrors(exception.Errors);
                responseData.SetStatus(HttpStatusCode.PreconditionFailed);
                throw;
            }
            return responseData;
        }

        [Route("{id}")]
        [HttpPut]
        public IResponseData<string> UpdatePermission([FromBody] AddPermissionRequest request, [FromUri] string id)
        {
            IResponseData<string> responseData = new ResponseData<string>();
            try
            {
                IPermissionService permissionService = IoC.Container.Resolve<IPermissionService>();
                permissionService.Updatepermission(request, id);
            }
            catch (ValidationException exception)
            {
                responseData.SetErrors(exception.Errors);
                responseData.SetStatus(HttpStatusCode.PreconditionFailed);

            }
            return responseData;
        }


        [Route("")]
        [HttpPost]
        public IResponseData<string> AddPermission([FromBody] AddPermissionRequest request)
        {
            IResponseData<string> responseData = new ResponseData<string>();
            try
            {
                IPermissionService permissionService = IoC.Container.Resolve<IPermissionService>();
                permissionService.AddPermission(request);
            }
            catch (ValidationException exception)
            {
                responseData.SetErrors(exception.Errors);
                responseData.SetStatus(HttpStatusCode.PreconditionFailed);
            }
            return responseData;
        }

        [Route("{id}")]
        [HttpDelete]
        public IResponseData<string> DeletePermission([FromUri]string id)
        {
            IResponseData<string> responseData = new ResponseData<string>();
            try
            {
                IPermissionService permissionService = IoC.Container.Resolve<IPermissionService>();
                permissionService.DeletePermission(id);

            }
            catch (ValidationException exception)
            {
                responseData.SetErrors(exception.Errors);
                responseData.SetStatus(HttpStatusCode.PreconditionFailed);
            }
            return responseData;
        }
    }
}
