using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Emails.Commands.Models
{
    public class SendEmailCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Msg { get; set; }
    }
}
