using SchoolManagment.Data.Entities.Identity;

namespace SchoolManagment.Service.Abstracts
{
    public interface IAuthenticationService
    {
        public Task<string> GetJWTToken(User user);
    }
}
