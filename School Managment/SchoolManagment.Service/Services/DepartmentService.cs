using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Infrustructure.Abstract;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        #endregion
        #region Ctor

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }


        #endregion
        #region Handler
        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository.GetTableNoTracking()
            .Where(d => d.DID.Equals(id))
            .Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subject)
            .Include(x => x.Students)
            .Include(x => x.Instructors)
            .Include(x => x.Instructor)
            .FirstOrDefaultAsync();
            return department;
        }
        #endregion

    }
}
