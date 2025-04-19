using SchoolManagment.Core.Features.Students.Queries.Results;
using SchoolManagment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Core.Mapping.Students
{
    public partial class StudentProfile

    {
        public void GetStudentByIDMapping()
        {
            CreateMap<Student, GetSingleStudentResponse>().ForMember(dest => dest.DeptName, opt => opt.MapFrom(src => src.Department.Name));
        }
    }
}
