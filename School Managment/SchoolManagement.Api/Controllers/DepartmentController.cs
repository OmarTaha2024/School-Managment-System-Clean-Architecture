using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Api.Base;
using SchoolManagment.Core.Features.Departments.Queries.Models;
using SchoolManagment.Data.AppMetaData;

namespace SchoolManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentRouting.GetByID)]

        public async Task<IActionResult> GetDepartmentById([FromQuery] GetDepartmentByIDQuery query)
        {
            var responce = await Mediator.Send(query);
            return NewResult(responce);
        }
    }
}
