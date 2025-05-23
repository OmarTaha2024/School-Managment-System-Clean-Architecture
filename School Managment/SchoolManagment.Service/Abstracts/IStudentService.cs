﻿using SchoolManagment.Data.Entities;
using SchoolManagment.Data.Enums;

namespace SchoolManagment.Service.Abstracts
{
    public interface IStudentService
    {

        public Task<List<Student>> GetStudentsListAsync();
        public IQueryable<Student> GetStudentsQueryableList();
        public IQueryable<Student> GetStudentQueryableList(int id);
        public IQueryable<Student> FilterStudentsPaginatedQueryable(StudentOrderingEnum orderingEnum, string search);

        public Task<Student> GetStudentsByIdwithIncludeAsync(int id);
        public Task<Student> GetStudentsByIdAsync(int id);
        public Task<String> AddAsync(Student student);
        public Task<String> UpdataAsync(Student student);
        public Task<String> DeleteAsync(Student student);
        public Task<bool> IsNameExistEn(string name);
        public Task<bool> IsNameExistAr(string name);
        public Task<bool> IsNameExistExcludeSelfAr(string name, int id);
        public Task<bool> IsNameExistExcludeSelfEn(string name, int id);

    }
}
