using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Api.Base;
using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Core.Features.Students.Queries.Models;
using SchoolManagment.Data.AppMetaData;

namespace SchoolManagement.Api.Controllers
{
    [ApiController]
    //[Authorize(Roles = "admin")]
    public class StudentController : AppControllerBase
    {
        #region API
        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentsList()
        {
            var responce = await Mediator.Send(new GetStudentListQuery());
            return Ok(responce);
        }
        [HttpGet(Router.StudentRouting.paginated)]
        public async Task<IActionResult> GetStudentspaginatedList([FromQuery] GetStudentPaginatedListQuery query)
        {
            var responce = await Mediator.Send(query);
            return Ok(responce);
        }
        [HttpGet(Router.StudentRouting.GetByID)]

        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var responce = await Mediator.Send(new GetStudentByIDQuery(id));
            return NewResult(responce);
        }
        [Authorize(Policy = "CreateStudent")]
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand _command)
        {
            var responce = await Mediator.Send(_command);
            return NewResult(responce);
        }
        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand _command)
        {
            var responce = await Mediator.Send(_command);
            return NewResult(responce);
        }
        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> DeleteStudent([FromBody] DeleteStudentCommand _command)
        {
            var responce = await Mediator.Send(_command);
            return NewResult(responce);
        }
        #endregion

    }
}
