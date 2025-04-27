using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Data.Enums;
using SchoolManagment.Infrustructure.Abstract;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Service.Services
{
    public class StudentService : IStudentService
    {
        #region Fields
        private readonly IStudentRepository _StudentRepository;
        #endregion
        #region Ctor

        public StudentService(IStudentRepository IStudentRepository)
        {
            _StudentRepository = IStudentRepository;
        }


        #endregion
        #region Handle Function

        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _StudentRepository.GetStudentsListAsync();
        }
        public async Task<Student> GetStudentsByIdAsync(int id)
        {
            // var srudent = await _IStudentRepository.GetByIdAsync(id);
            // will return one record only and No track
            var student = _StudentRepository.GetTableNoTracking()
                .Where(s => s.StudentId.Equals(id))
                .FirstOrDefault();
            return student;
        }
        public async Task<Student> GetStudentsByIdwithIncludeAsync(int id)
        {
            // var srudent = await _IStudentRepository.GetByIdAsync(id);
            // will return one record only and No track
            var student = _StudentRepository.GetTableNoTracking()
                .Include(x => x.Department)
                .Where(s => s.StudentId.Equals(id))
                .FirstOrDefault();
            return student;
        }
        public async Task<string> AddAsync(Student student)
        {
            // check if name is exist 
            var studentResult = _StudentRepository.GetTableNoTracking().Where(s => s.Name.Equals(student.Name)).FirstOrDefault();
            if (studentResult != null)
                return "Exist";
            // Add Student 
            await _StudentRepository.AddAsync(student);
            return "Added Successfully";
        }

        public async Task<bool> IsNameExist(string name)
        {
            var studentResult = _StudentRepository.GetTableNoTracking().Where(s => s.Name.Equals(name)).FirstOrDefault();
            if (studentResult == null)
                return false;
            return true;
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            var studentResult = await _StudentRepository.GetTableNoTracking().Where(s => s.Name.Equals(name) & !s.StudentId.Equals(id)).FirstOrDefaultAsync();
            if (studentResult == null)
                return false;
            return true;

        }

        public async Task<string> UpdataAsync(Student student)
        {
            await _StudentRepository.UpdateAsync(student);
            return "Updated Successfully";
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var trans = _StudentRepository.BeginTransaction();
            try
            {
                await _StudentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "Deleted Successfully";
            }
            catch
            {
                await trans.RollbackAsync();
                return "falied";
            }

        }

        public IQueryable<Student> GetStudentsQueryableList()
        {
            return _StudentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
        }

        public IQueryable<Student> FilterStudentsPaginatedQueryable(StudentOrderingEnum orderingEnum, string search)
        {
            var querable = _StudentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            if (search != null)
            {
                querable = querable.Where(s => s.Name.Contains(search) || s.Address.Contains(search));

            }
            switch (orderingEnum)
            {
                case StudentOrderingEnum.StudID:
                    querable = querable.OrderBy(x => x.StudentId);
                    break;
                case StudentOrderingEnum.Name:
                    querable = querable.OrderBy(x => x.Name);
                    break;
                case StudentOrderingEnum.Address:
                    querable = querable.OrderBy(x => x.Address);
                    break;
                case StudentOrderingEnum.DepartmentName:
                    querable = querable.OrderBy(x => x.Department.Name);
                    break;
            }

            return querable;
        }


        #endregion

    }
}
