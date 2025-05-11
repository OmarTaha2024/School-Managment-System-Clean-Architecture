using SchoolManagment.Data.Requests;

namespace SchoolManagment.Service.Abstracts
{
    public interface IAuthorizationService
    {
        public Task<string> AddRoleAsync(string roleName);
        public Task<bool> IsRoleExistByName(string roleName);
        public Task<string> EditRoleAsync(EditRoleRequest editRoleRequest);
    }
}
