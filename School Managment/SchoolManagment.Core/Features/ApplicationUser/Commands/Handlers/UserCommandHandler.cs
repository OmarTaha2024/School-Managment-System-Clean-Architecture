using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.ApplicationUser.Commands.Models;
using SchoolManagment.Core.Resources;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Core.Features.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
        IRequestHandler<AddUserCommand, Response<string>>,
        IRequestHandler<EditUserCommand, Response<string>>,
        IRequestHandler<DeleteUserCommand, Response<string>>,
        IRequestHandler<ChangeUserPasswordCommand, Response<string>>

    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _sharedResources;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _IemailService;
        private readonly IApplicationUserService _applicationUserService;
        #endregion
        #region CTOR

        public UserCommandHandler(IMapper mapper, UserManager<User> userManager, IStringLocalizer<SharedResources> stringLocalizer, IHttpContextAccessor httpContextAccessor, IEmailService IemailService, IApplicationUserService applicationUserService) : base(stringLocalizer)
        {
            _mapper = mapper;
            _userManager = userManager;
            _sharedResources = stringLocalizer;
            _httpContextAccessor = httpContextAccessor;
            _IemailService = IemailService;
            _applicationUserService = applicationUserService;
        }
        #endregion
        #region Handle function

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            // if Email is Exist 
            var identityUser = _mapper.Map<User>(request);
            //Create
            var createResult = await _applicationUserService.AddUserAsync(identityUser, request.Password);
            switch (createResult)
            {
                case "EmailIsExist": return BadRequest<string>(_sharedResources[SharedResourcesKeys.EmailIsExist]);
                case "UserNameIsExist": return BadRequest<string>(_sharedResources[SharedResourcesKeys.UserNameIsExist]);
                case "ErrorInCreateUser": return BadRequest<string>(_sharedResources[SharedResourcesKeys.FaildToAddUser]);
                case "Failed": return BadRequest<string>(_sharedResources[SharedResourcesKeys.TryToRegisterAgain]);
                case "Success": return Success<string>("");
                default: return BadRequest<string>(createResult);
            }
        }

        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            //check if USER is exsit or not 
            var user = await _userManager.FindByEmailAsync(request.Email);
            // return not found 
            if (user == null) return NotFound<string>();
            var usermapper = _mapper.Map(request, user);
            var result = await _userManager.UpdateAsync(usermapper);
            if (result.Succeeded)
                return Success<string>(_sharedResources[SharedResourcesKeys.Success]);
            return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            //check if USER is exsit or not 
            var user = await _userManager.FindByEmailAsync(request.Email);
            // return not found 
            if (user == null) return NotFound<string>();
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                return Success<string>(_sharedResources[SharedResourcesKeys.Success]);
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            //check if USER is exsit or not 
            var user = await _userManager.FindByEmailAsync(request.Email);
            // return not found 
            if (user == null) return NotFound<string>();
            //Change User Password
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            //result
            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            return Success((string)_sharedResources[SharedResourcesKeys.Success]);
        }
        #endregion

    }
}
