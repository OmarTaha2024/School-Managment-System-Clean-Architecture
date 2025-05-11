using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Api.Base;
using SchoolManagment.Core.Features.Authorization.Commands.Models;
using SchoolManagment.Core.Features.Authorization.Quaries.Models;
using SchoolManagment.Data.AppMetaData;

namespace SchoolManagement.Api.Controllers
{
    [ApiController]
    public class AuthorizationController : AppControllerBase
    {

        [HttpGet(Router.AuthorizationRouting.RoleList)]
        public async Task<IActionResult> RoleList()
        {
            var response = await Mediator.Send(new GetRolesListQuery());
            return NewResult(response);
        }
        [HttpPost(Router.AuthorizationRouting.Create)]
        public async Task<IActionResult> AddRole([FromForm] AddRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.AuthorizationRouting.Update)]
        public async Task<IActionResult> EditRole([FromForm] EditRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.AuthorizationRouting.Delete)]
        public async Task<IActionResult> DeleteRole([FromForm] string name)
        {
            var response = await Mediator.Send(new DeleteRoleCommand(name));
            return NewResult(response);
        }
    }
}
