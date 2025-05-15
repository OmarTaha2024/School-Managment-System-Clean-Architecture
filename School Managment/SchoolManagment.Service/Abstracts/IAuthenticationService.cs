using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Results;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolManagment.Service.Abstracts
{
    public interface IAuthenticationService
    {
        public Task<JwtAuthResult> GetJWTToken(User user);
        public Task<JwtAuthResult> GetRefreshToken(User user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken);
        public Task<string> ValidateToken(string accessToken);
        public JwtSecurityToken ReadJWTToken(string accessToken);
        public Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string AccessToken, string RefreshToken);
        public Task<string> ConfirmEmail(string? userId, string? code);
        public Task<string> SendResetPasswordCode(string Email);
    }
}
