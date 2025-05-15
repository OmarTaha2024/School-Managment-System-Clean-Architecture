using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Authentication.Commands.Models;
using SchoolManagment.Core.Resources;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Helpers;
using SchoolManagment.Data.Results;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler,
        IRequestHandler<SignInCommand, Response<JwtAuthResult>>,
        IRequestHandler<RefreshTokenCommand, Response<JwtAuthResult>>,
        IRequestHandler<ResetPasswordCommand, Response<string>>
    {

        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly JwtSettings _jwtSettings;

        #endregion

        #region Constructors
        public AuthenticationCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                            UserManager<User> userManager,
                                            SignInManager<User> signInManager,
                                            IAuthenticationService authenticationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationService = authenticationService;
        }


        #endregion

        public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            //Check if user is exist or not
            var user = await _userManager.FindByNameAsync(request.UserName);
            //Return The UserName Not Found
            if (user == null) return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.UserNameIsNotExist]);

            //try To Sign in 
            var signInResult = _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!user.EmailConfirmed) return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.EmailNotConfirmed]);
            //if Failed Return Passord is wrong
            if (!signInResult.IsCompletedSuccessfully) return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.PasswordNotCorrect]);

            //Generate Token
            var result = await _authenticationService.GetJWTToken(user);
            //return Token 
            return Success(result);
        }

        public async Task<Response<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var token = _authenticationService.ReadJWTToken(request.AccessToken);
            var userIdAndExpireDate = await _authenticationService.ValidateDetails(token, request.AccessToken, request.RefreshToken);
            switch (userIdAndExpireDate)
            {
                case ("AlgorithmIsWrong", null): return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.AlgorithmIsWrong]);
                case ("TokenIsNotExpired", null): return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.TokenIsNotExpired]);
                case ("RefreshTokenIsNotFound", null): return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.RefreshTokenIsNotFound]);
                case ("RefreshTokenIsExpired", null): return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.RefreshTokenIsExpired]);
            }
            var (userId, expiryDate) = userIdAndExpireDate;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound<JwtAuthResult>();
            }
            var result = await _authenticationService.GetRefreshToken(user, token, expiryDate, request.RefreshToken);
            return Success(result);
        }

        public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.SendResetPasswordCode(request.Email);
            switch (result)
            {
                case "UserNotFound": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);
                case "ErrorInUpdateUser": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.TryAgainInAnotherTime]);
                case "Failed": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.TryAgainInAnotherTime]);
                case "Success": return Success<string>("");
                default: return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.TryAgainInAnotherTime]);
            }
        }
    }
}
