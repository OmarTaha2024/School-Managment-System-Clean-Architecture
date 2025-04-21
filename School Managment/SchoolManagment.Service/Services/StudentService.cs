using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;
using SchoolManagment.Infrustructure.Abstract;
using SchoolManagment.Infrustructure.Data;
using SchoolManagment.Infrustructure.Represatories;
using SchoolManagment.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Include(x =>x.Department)
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
        #endregion

    }
}
