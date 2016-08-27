using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using App.Common.DI;
using App.Common.Http;
using App.Common.Validation;
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
    }
}
