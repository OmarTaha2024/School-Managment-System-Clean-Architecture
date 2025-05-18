using SchoolManagment.Data.Entities.Identity;

namespace SchoolManagment.Service.AuthServices.Interfaces
{
    public interface ICurrentUserService
    {
        public Task<User> GetUserAsync();
        public string GetUserId();
        public Task<List<string>> GetCurrentUserRolesAsync();
    }
}
