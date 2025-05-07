using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Authentication.Queries.Models
{
    public class AuthorizeUserQuery : IRequest<Response<string>>
    {
        public string AccessToken { get; set; }
    }
}
