using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Departments.Queries.Results;

namespace SchoolManagment.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentByIDQuery : IRequest<Response<GetSingleDepartmentResponse>>
    {
        public int ID { get; set; }
        public GetDepartmentByIDQuery(int id)
        {
            ID = id;
        }
    }
}
