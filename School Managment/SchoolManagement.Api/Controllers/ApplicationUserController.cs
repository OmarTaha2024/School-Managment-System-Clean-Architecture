using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Api.Base;
using SchoolManagment.Core.Features.ApplicationUser.Commands.Models;
using SchoolManagment.Core.Features.ApplicationUser.Queries.Models;
using SchoolManagment.Data.AppMetaData;

namespace SchoolManagement.Api.Controllers
{
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {

        [HttpGet(Router.ApplicationUserRouting.paginated)]
        public async Task<IActionResult> GetUserspaginatedList([FromQuery] GetUserPaginationQuery query)
        {
            var responce = await Mediator.Send(query);
            return Ok(responce);
        }
        [HttpGet(Router.ApplicationUserRouting.Email)]

        public async Task<IActionResult> GetUserByEmail([FromRoute] string email)
        {
            var responce = await Mediator.Send(new GetUserByEmailQuery(email));
            return NewResult(responce);
        }
        [HttpPost(Router.ApplicationUserRouting.Create)]

        public async Task<IActionResult> AddUser([FromBody] AddUserCommand _command)
        {
            var responce = await Mediator.Send(_command);
            return NewResult(responce);
        }
        [HttpPut(Router.ApplicationUserRouting.Edit)]
        public async Task<IActionResult> Edituser([FromBody] EditUserCommand _command)
        {
            var responce = await Mediator.Send(_command);
            return NewResult(responce);
        }
        [HttpPut(Router.ApplicationUserRouting.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.ApplicationUserRouting.Delete)]
        public async Task<IActionResult> Deleteuser([FromBody] DeleteUserCommand _command)
        {
            var responce = await Mediator.Send(_command);
            return NewResult(responce);
        }
    }
}
