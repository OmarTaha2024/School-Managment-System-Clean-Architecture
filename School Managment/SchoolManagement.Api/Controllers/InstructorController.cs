using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Api.Base;
using SchoolManagment.Core.Features.Instructors.Commands.Model;
using SchoolManagment.Core.Features.Instructors.Queries.Models;
using SchoolManagment.Data.AppMetaData;

namespace SchoolManagement.Api.Controllers
{
    [ApiController]
    public class InstructorController : AppControllerBase
    {
        [HttpGet(Router.InstructorRouting.GetSalarySummationOfInstructor)]
        public async Task<IActionResult> GetSalarySummation()
        {
            return NewResult(await Mediator.Send(new GetSummationSalaryOfInstructorQuery()));
        }
        [HttpPost(Router.InstructorRouting.AddInstructor)]
        public async Task<IActionResult> AddInstructor([FromForm] AddInstructorCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
    }
}
