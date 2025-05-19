using SchoolManagment.Data.Entities.Procedures;

namespace SchoolManagment.Infrustructure.Abstract.Procedures
{
    public interface IDepartmentStudentCountProcRepository
    {
        public Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcs(DepartmentStudentCountProcParameter parameters);
    }
}
