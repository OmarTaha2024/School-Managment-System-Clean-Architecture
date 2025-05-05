using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.ApplicationUser.Queries.Results;

namespace SchoolManagment.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUserByEmailQuery : IRequest<Response<GetUserByEmailResponse>>
    {
        public string Email { get; set; }
        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
