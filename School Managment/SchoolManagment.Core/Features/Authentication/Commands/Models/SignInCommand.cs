using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Data.Results;

namespace SchoolManagment.Core.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<JwtAuthResult>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
