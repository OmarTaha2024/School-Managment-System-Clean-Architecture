using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<Response<String>>
    {
        public string Name { get; set; }

        public string Address { get; set; }
        public string? Phone { get; set; }

        public int DepartmentID { get; set; }
    }
}
