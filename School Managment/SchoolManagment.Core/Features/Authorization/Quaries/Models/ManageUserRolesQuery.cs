using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Data.Results;

namespace SchoolManagment.Core.Features.Authorization.Quaries.Models
{
    public class ManageUserRolesQuery : IRequest<Response<ManageUserRolesResult>>
    {
        public string UserId { get; set; }
    }
}
