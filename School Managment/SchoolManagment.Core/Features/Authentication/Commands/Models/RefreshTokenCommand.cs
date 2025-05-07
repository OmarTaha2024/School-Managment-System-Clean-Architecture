using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Data.Results;

namespace SchoolManagment.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand : IRequest<Response<JwtAuthResult>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
