using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.ApplicationUser.Commands.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public DeleteUserCommand(string email)
        {
            Email = email;
        }
    }
}
