using SchoolManagment.Data.Entities.Identity;

namespace SchoolManagment.Service.Abstracts
{
    public interface IApplicationUserService
    {
        public Task<string> AddUserAsync(User user, string password);
    }
}
