using Microsoft.AspNetCore.Http;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Service.Abstracts
{
    public interface IInstructorService
    {
        public Task<decimal> GetSalarySummationOfInstructor();
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<string> AddInstructorAsync(Instructor instructor, IFormFile file);
    }
}
