using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void EditStudentCommandMapping()
        {
            CreateMap<EditStudentCommand, Student>()
                .ForMember(dest => dest.Did, opt => opt.MapFrom(src => src.DepartmentID))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
