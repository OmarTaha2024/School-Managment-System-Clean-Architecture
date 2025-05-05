using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.ApplicationUser.Commands.Models
{
    public class EditUserCommand : IRequest<Response<string>>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
