using SchoolManagment.Data.Entities;
using SchoolManagment.Data.Entities.Procedures;
using SchoolManagment.Data.Entities.Views;

namespace SchoolManagment.Service.Abstracts
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentByIdAsync(int id);
        public Task<bool> IsDeptExist(int id);
        public Task<List<ViewDepartment>> GetViewDepartmentDataAsync();
        public Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcsService(DepartmentStudentCountProcParameter parameters);

    }
}
