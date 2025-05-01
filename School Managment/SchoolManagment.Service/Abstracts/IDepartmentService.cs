using SchoolManagment.Data.Entities;

namespace SchoolManagment.Service.Abstracts
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentByIdAsync(int id);

    }
}
