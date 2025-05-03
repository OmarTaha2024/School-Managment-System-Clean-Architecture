using SchoolManagment.Core.Features.Departments.Queries.Results;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentByIDMapping()
        {
            CreateMap<Department, GetSingleDepartmentResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalized(src.DNameAr, src.DNameEn)))
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.DID))
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.GetLocalized(src.Instructor.ENameAr, src.Instructor.ENameEn)))
                .ForMember(dest => dest.subjectList, opt => opt.MapFrom(src => src.DepartmentSubjects))
                .ForMember(dest => dest.InstructorsList, opt => opt.MapFrom(src => src.Instructors));
            //  .ForMember(dest => dest.studentList, opt => opt.MapFrom(src => src.Students));


            CreateMap<DepartmetSubject, SubjectResponse>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.SubID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subject.GetLocalized(src.Subject.SubjectNameAr, src.Subject.SubjectNameEn)));

            CreateMap<Instructor, InstructorsResponse>()
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.InsId))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalized(src.ENameAr, src.ENameEn)));

            //CreateMap<Student, StudentResponse>()
            //   .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.StudID))
            //   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalized(src.NameAr, src.NameEn)));
        }
    }
}
