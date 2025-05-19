using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Departments.Queries.Results;

namespace SchoolManagment.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentStudentCountByIDQuery : IRequest<Response<GetDepartmentStudentCountByIDResult>>
    {
        public int DID { get; set; }
    }
}
