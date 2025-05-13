using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Helpers;
using SchoolManagment.Data.Results;
using SchoolManagment.Infrustructure.Abstract;
using SchoolManagment.Service.Abstracts;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
namespace SchoolManagment.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields
        private readonly JwtSettings _jwtSettings;
        //private readonly ConcurrentDictionary<string, RefreshToken> _userRefreshToken;
        private readonly IRefreshTokenRepository _RefreshToken;
        private readonly UserManager<User> _userManager;

        #endregion
        #region  Ctor
        public AuthenticationService(UserManager<User> userManager, JwtSettings jwtSettings, ConcurrentDictionary<string, RefreshToken> userRefreshToken, IRefreshTokenRepository RefreshToken)
        {
            _jwtSettings = jwtSettings;
            //_userRefreshToken = userRefreshToken;
            _RefreshToken = RefreshToken;
            _userManager = userManager;
        }
        #endregion
        #region Actions
        public async Task<JwtAuthResult> GetJWTToken(User user)
        {
            var (JWTToken, AccessToken) = await GenerateJWTToken(user);

            var refreshToken = GetRefreshToken(user.UserName);
            var userRefreshToken = new UserRefreshToken
            {
                AddedTime = DateTime.Now,
                ExpiryDate = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                IsUsed = true,
                IsRevoked = false,
                JwtId = JWTToken.Id,
                RefreshToken = refreshToken.TokenString,
                Token = AccessToken,
                UserId = user.Id
            };
            await _RefreshToken.AddAsync(userRefreshToken);
            //_userRefreshToken.AddOrUpdate(refreshToken.TokenString, refreshToken, (s, t) => refreshToken);

            var response = new JwtAuthResult();
            response.AccessToken = AccessToken;
            response.refreshToken = refreshToken;
            return response;
        }
        private RefreshToken GetRefreshToken(string username)
        {
            var refreshToken = new RefreshToken
            {
                ExpireAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                UserName = username,
                TokenString = GenerateRefreshToken()
            };
            return refreshToken;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var randomNumberGenerate = RandomNumberGenerator.Create();
            randomNumberGenerate.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        public async Task<List<Claim>> GetClaims(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var userclaims = await _userManager.GetClaimsAsync(user);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(nameof(UserClaimModel.PhoneNumber), user.PhoneNumber),
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            claims.AddRange(userclaims);
            return claims;
        }
        private async Task<(JwtSecurityToken, string)> GenerateJWTToken(User user)
        {
            var claims = await GetClaims(user);
            var jwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return (jwtToken, accessToken);
        }
        public JwtSecurityToken ReadJWTToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }
            var handler = new JwtSecurityTokenHandler();
            var response = handler.ReadJwtToken(accessToken);
            return response;
        }
        public async Task<string> ValidateToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = _jwtSettings.ValidateIssuer,
                ValidIssuers = new[] { _jwtSettings.Issuer },
                ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
                ValidAudience = _jwtSettings.Audience,
                ValidateAudience = _jwtSettings.ValidateAudience,
                ValidateLifetime = _jwtSettings.ValidateLifeTime,
            };
            try
            {
                var validator = handler.ValidateToken(accessToken, parameters, out SecurityToken validatedToken);

                if (validator == null)
                {
                    return "InvalidToken";
                }

                return "NotExpired";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<JwtAuthResult> GetRefreshToken(User user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken)
        {
            var (jwtSecurityToken, newToken) = await GenerateJWTToken(user);
            var response = new JwtAuthResult();
            response.AccessToken = newToken;
            var refreshTokenResult = new RefreshToken();
            refreshTokenResult.UserName = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimModel.UserName)).Value;
            refreshTokenResult.TokenString = refreshToken;
            refreshTokenResult.ExpireAt = (DateTime)expiryDate;
            response.refreshToken = refreshTokenResult;
            return response;

        }
        public async Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshToken)
        {
            // read token
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            {
                return ("AlgorithmIsWrong", null);
            }
            if (jwtToken.ValidTo > DateTime.UtcNow)
            {
                return ("TokenIsNotExpired", null);

            }
            var email = jwtToken.Claims.FirstOrDefault(x => x.Type.Equals(nameof(UserClaimModel.Email))).Value;
            var userrefreshtoken = _RefreshToken.GetTableNoTracking().FirstOrDefault(t => t.Token == accessToken
                                                                            && t.RefreshToken == refreshToken);
            var user = await _userManager.FindByEmailAsync(email);
            if (userrefreshtoken == null)
            {
                return ("RefreshTokenIsNotFound", null);

            }
            if (user == null)
            {
                return ("RefreshTokenIsExpired", null);

            }
            if (userrefreshtoken.ExpiryDate < DateTime.UtcNow)
            {
                userrefreshtoken.IsRevoked = true;
                userrefreshtoken.IsUsed = false;
                _RefreshToken.UpdateAsync(userrefreshtoken);
                throw new SecurityTokenException("Refresh Token IS NOT EXPIRED");

            }
            var expirydate = userrefreshtoken.ExpiryDate;
            return (user.Id, expirydate);
        }



        #endregion

    }
}
