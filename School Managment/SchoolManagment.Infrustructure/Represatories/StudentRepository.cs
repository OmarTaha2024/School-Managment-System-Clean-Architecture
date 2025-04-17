using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Infrustructure.Abstract;
using SchoolManagment.Infrustructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Infrustructure.Represatories
{
    public class StudentRepository : IStudentRepository
    {
        #region Fields
        private readonly ApplicationDbContext _dbContext;
        #endregion
        #region Ctor

        public StudentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion
        #region Handle Function

        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _dbContext.Students.Include(S => S.Department).ToListAsync();
        }
        #endregion

    }
}
