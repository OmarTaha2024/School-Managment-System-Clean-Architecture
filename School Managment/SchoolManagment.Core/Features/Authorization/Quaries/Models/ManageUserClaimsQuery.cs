using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Data.Results;

namespace SchoolManagment.Core.Features.Authorization.Quaries.Models
{
    public class ManageUserClaimsQuery : IRequest<Response<ManageUserclaimsResult>>
    {
        public string UserID { get; set; }
    }
}
