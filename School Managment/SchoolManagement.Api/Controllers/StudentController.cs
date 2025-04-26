using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Api.Base;
using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Core.Features.Students.Queries.Models;
using SchoolManagment.Data.AppMetaData;

namespace SchoolManagement.Api.Controllers
{
    [ApiController]
    public class StudentController : AppControllerBase
    {
        #region API
        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentsList()
        {
            var responce = await Mediator.Send(new GetStudentListQuery());
            return Ok(responce);
        }
        [HttpGet(Router.StudentRouting.GetByID)]

        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var responce = await Mediator.Send(new GetStudentByIDQuery(id));
            return NewResult(responce);
        }
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
        #endregion

    }
}
