using SchoolManagment.Core.Features.Departments.Queries.Results;
using SchoolManagment.Data.Entities.Views;


namespace SchoolManagment.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentStudentCountMapping()
        {
            CreateMap<ViewDepartment, GetDepartmentStudentListCountResults>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalized(src.DNameAr, src.DNameEn)))
                .ForMember(dest => dest.StudentCount, opt => opt.MapFrom(src => src.Student_count));
        }
    }
}
