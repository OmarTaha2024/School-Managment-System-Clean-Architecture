using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Core.Features.Students.Queries.Models;
using SchoolManagment.Data.AppMetaData;

namespace SchoolManagement.Api.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        #region Fileds
        private readonly IMediator _mediator;
        #endregion
        #region CTOR
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion
        #region API
        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentsList()
        {
            var responce = await _mediator.Send(new GetStudentListQuery());
            return Ok(responce);
        }
        [HttpGet(Router.StudentRouting.GetByID)]

        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var responce = await _mediator.Send(new GetStudentByIDQuery(id));
            return Ok(responce);
        }
        [HttpGet(Router.StudentRouting.Create)]

        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand _command) 
        {
            var responce = await _mediator.Send(_command);
            return Ok(responce);
        }
        #endregion

    }
}
