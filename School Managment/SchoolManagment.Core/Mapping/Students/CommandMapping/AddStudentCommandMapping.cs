using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void AddStudentCommandMapping()
        {
            CreateMap<AddStudentCommand, Student>()
                .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentID))
                .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.NameEn))
               .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.NameAr));
        }
    }
}
