using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Commons;

namespace SchoolManagment.Data.Entities.Procedures
{
    [Keyless]
    public class DepartmentStudentCountProc : GeneralLocalizableEntity
    {
        public int DID { get; set; }
        public string? DNameAr { get; set; }
        public string? DNameEn { get; set; }
        public int StudentCount { get; set; }
    }
    public class DepartmentStudentCountProcParameter
    {
        public int did { get; set; }
    }
}
