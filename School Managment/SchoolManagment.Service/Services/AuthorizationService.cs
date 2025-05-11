using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Requests;
using SchoolManagment.Data.Results;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Service.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        #region fields
        private readonly RoleManager<IdentityRole> _role;
        private readonly UserManager<User> _user;

        #endregion
        #region ctor
        public AuthorizationService(
       RoleManager<IdentityRole> role, UserManager<User> user)
        {
            _role = role;
            _user = user;
        }

        #endregion

        public async Task<string> AddRoleAsync(string roleName)
        {

            var identityRole = new IdentityRole();
            identityRole.Name = roleName;
            var result = await _role.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                return "Added";
            }
            return "Failed";
        }

        public async Task<string> DeleteRoleAsync(string roleName)
        {
            var role = await _role.FindByNameAsync(roleName);
            if (role == null)
            {
                return "Not Found";
            }
            var users = await _user.GetUsersInRoleAsync(roleName);
            if (users != null && users.Count() > 0) { return "Used"; }
            var result = await _role.DeleteAsync(role);
            if (result.Succeeded)
                return "Success";
            var error = string.Join("-", result.Errors);
            return error;
        }

        public async Task<string> EditRoleAsync(EditRoleRequest editRoleRequest)
        {
            var role = await _role.FindByNameAsync(editRoleRequest.oldName);
            if (role == null)
            {
                return "Not Found";
            }
            role.Name = editRoleRequest.NewName;
            var result = await _role.UpdateAsync(role);
            if (result.Succeeded)
                return "Success";
            var error = string.Join("-", result.Errors);
            return error;

        }

        public async Task<List<IdentityRole>> GetRolesList()
        {
            var roles = await _role.Roles.ToListAsync();
            return roles;
        }

        public async Task<bool> IsRoleExistByName(string roleName)
        {
            var result = await _role.RoleExistsAsync(roleName);
            if (result)
            {
                return true;
            }
            return false;
        }

        public async Task<ManageUserRolesResult> ManageUserRolesData(User user)
        {
            var response = new ManageUserRolesResult();
            var rolesList = new List<UserRoles>();
            //Roles
            var roles = await _role.Roles.ToListAsync();
            response.UserId = user.Id;
            foreach (var role in roles)
            {
                var userrole = new UserRoles();
                userrole.Id = role.Id;
                userrole.Name = role.Name;
                var result = await _user.IsInRoleAsync(user, role.Name);
                if (result)
                {
                    userrole.HasRole = true;
                }
                else
                {
                    userrole.HasRole = false;
                }
                rolesList.Add(userrole);
            }
            response.userRoles = rolesList;
            return response;
        }
    }
}
