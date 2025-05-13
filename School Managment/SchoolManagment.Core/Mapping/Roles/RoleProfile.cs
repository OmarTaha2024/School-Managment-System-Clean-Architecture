using AutoMapper;

namespace SchoolManagment.Core.Mapping.Roles
{
    public partial class RoleProfile : Profile
    {
        public RoleProfile()
        {
            GetRolesListMapping();
        }
    }
}
