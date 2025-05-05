using AutoMapper;

namespace SchoolManagment.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            AddUserCommandMapping();
        }
    }
}
