using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Data.Entities.Views;
using SchoolManagment.Infrustructure.Abstract;
using SchoolManagment.Infrustructure.Abstract.Views;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IViewRepository<ViewDepartment> _Iviewdepartment;
        #endregion
        #region Ctor

        public DepartmentService(IDepartmentRepository departmentRepository, IViewRepository<ViewDepartment> Iviewdepartment)
        {
            _departmentRepository = departmentRepository;
            _Iviewdepartment = Iviewdepartment;
        }


        #endregion
        #region Handler
        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository.GetTableNoTracking()
            .Where(d => d.DID.Equals(id))
            .Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subject)
            .Include(x => x.Instructors)
            .Include(x => x.Instructor)
            .FirstOrDefaultAsync();
            return department;
        }

        public async Task<List<ViewDepartment>> GetViewDepartmentDataAsync()
        {
            return await _Iviewdepartment.GetTableNoTracking().ToListAsync();
        }

        public async Task<bool> IsDeptExist(int id)
        {
            return await _departmentRepository.GetTableNoTracking().AnyAsync(x => x.DID.Equals(id));

        }
        #endregion

    }
}
