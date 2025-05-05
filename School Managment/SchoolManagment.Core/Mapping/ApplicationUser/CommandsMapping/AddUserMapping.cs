using SchoolManagment.Core.Features.ApplicationUser.Commands.Models;
using SchoolManagment.Data.Entities.Identity;

namespace SchoolManagment.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void AddUserCommandMapping()
        {
            CreateMap<AddUserCommand, User>();
        }
    }
}
