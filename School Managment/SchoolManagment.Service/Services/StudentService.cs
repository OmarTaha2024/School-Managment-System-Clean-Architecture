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
        private readonly IStudentRepository _IStudentRepository;
        #endregion
        #region Ctor

        public StudentService(IStudentRepository IStudentRepository)
        {
            _IStudentRepository = IStudentRepository;
        }
        #endregion
        #region Handle Function

        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _IStudentRepository.GetStudentsListAsync();
        }
        #endregion

    }
}
