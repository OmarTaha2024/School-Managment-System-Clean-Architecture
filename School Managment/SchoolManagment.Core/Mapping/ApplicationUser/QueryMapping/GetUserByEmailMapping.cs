using SchoolManagment.Core.Features.ApplicationUser.Queries.Results;
using SchoolManagment.Data.Entities.Identity;

namespace SchoolManagment.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void GetUserByEmailMapping()
        {
            CreateMap<User, GetUserByEmailResponse>();
        }
    }
}
