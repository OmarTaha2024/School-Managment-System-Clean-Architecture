using SchoolManagment.Data.Entities;

namespace SchoolManagment.Service.Abstracts
{
    public interface IStudentService
    {

        public Task<List<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentsByIdAsync(int id);
        public Task<String> AddAsync(Student student);
        public Task<bool> IsNameExist(string name);

    }
}
