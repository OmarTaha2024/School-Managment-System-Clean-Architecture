using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Authorization.Commands.Models
{
    public class DeleteRoleCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public DeleteRoleCommand(string name)
        {
            Name = name;
        }
    }
}
