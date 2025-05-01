using SchoolManagment.Core.Features.Students.Queries.Results;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentListResponse>().ForMember(dest => dest.DeptName, opt => opt.MapFrom(src => src.Department.GetLocalized(src.Department.DNameAr, src.Department.DNameEn)))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalized(src.NameAr, src.NameEn)));

        }
    }
}
