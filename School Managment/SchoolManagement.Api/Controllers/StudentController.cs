using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Core.Features.Students.Queries.Models;

namespace SchoolManagement.Api.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet("/Student/List")]
        public async Task<IActionResult> GetStudentsList()
        {
            var responce = await _mediator.Send(new GetStudentListQuery());
            return Ok(responce);
        }
        #endregion

    }
}
