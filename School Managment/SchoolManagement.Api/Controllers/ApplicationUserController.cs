using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Api.Base;
using SchoolManagment.Core.Features.ApplicationUser.Commands.Models;
using SchoolManagment.Data.AppMetaData;

namespace SchoolManagement.Api.Controllers
{
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        [HttpPost(Router.ApplicationUserRouting.Create)]

        public async Task<IActionResult> AddUser([FromBody] AddUserCommand _command)
        {
            var responce = await Mediator.Send(_command);
            return NewResult(responce);
        }
    }
}
