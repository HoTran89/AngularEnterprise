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
        public IResponseData<IList<PermissionListItem>> getPermissions()
        {
            IResponseData<IList<PermissionListItem>> responseData = new ResponseData<IList<PermissionListItem>>();
            try
            {
                IPermissionService permissionsService = IoC.Container.Resolve<IPermissionService>();
                IList<PermissionListItem> listItemses = permissionsService.GetPermissons();
                responseData.SetData(listItemses);
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
