using AutoMapper;

namespace SchoolManagment.Core.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetDepartmentByIDMapping();
            GetDepartmentStudentCountMapping();
        }
    }
}
