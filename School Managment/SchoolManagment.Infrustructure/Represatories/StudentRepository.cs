using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Infrustructure.Abstract;
using SchoolManagment.Infrustructure.Context;
using SchoolManagment.Infrustructure.InfrustructureBases;

namespace SchoolManagment.Infrustructure.Represatories
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        #region Fields
        protected readonly DbSet<Student> _students;

        #endregion
        #region Ctor

        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _students = dbContext.Set<Student>();

        }
        #endregion
        #region Handle Function

        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _students.Include(S => S.Department).ToListAsync();
        }
        #endregion

    }
}
