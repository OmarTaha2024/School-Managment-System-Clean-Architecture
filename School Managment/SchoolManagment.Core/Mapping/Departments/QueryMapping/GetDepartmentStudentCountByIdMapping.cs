using SchoolManagment.Core.Features.Departments.Queries.Models;
using SchoolManagment.Core.Features.Departments.Queries.Results;
using SchoolManagment.Data.Entities.Procedures;

namespace SchoolManagment.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentStudentCountByIdMapping()
        {
            CreateMap<GetDepartmentStudentCountByIDQuery, DepartmentStudentCountProcParameter>()
                .ForMember(dest => dest.did, opt => opt.MapFrom(src => src.DID));

            CreateMap<DepartmentStudentCountProc, GetDepartmentStudentCountByIDResult>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetLocalized(src.DNameAr, src.DNameEn)))
                .ForMember(dest => dest.StudentCount, opt => opt.MapFrom(src => src.StudentCount));
        }
    }
}
