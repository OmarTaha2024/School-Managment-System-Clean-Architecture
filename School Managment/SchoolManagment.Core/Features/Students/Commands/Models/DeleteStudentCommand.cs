using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand : IRequest<Response<String>>
    {
        public int ID { get; set; }
        public DeleteStudentCommand(int id)
        {
            ID = id;
        }
    }
}
