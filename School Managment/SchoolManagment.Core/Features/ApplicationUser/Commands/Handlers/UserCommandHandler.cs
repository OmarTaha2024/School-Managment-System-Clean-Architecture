using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.ApplicationUser.Commands.Models;
using SchoolManagment.Core.Resources;
using SchoolManagment.Data.Entities.Identity;

namespace SchoolManagment.Core.Features.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _sharedResources;
        private readonly UserManager<User> _userManager;
        #endregion
        #region CTOR

        public UserCommandHandler(IMapper mapper, UserManager<User> userManager, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _mapper = mapper;
            _userManager = userManager;
            _sharedResources = stringLocalizer;
        }
        #endregion
        #region Handle function

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            // if Email is Exist 
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                //mapping 
                var Usermapper = _mapper.Map<User>(request);
                // create 
                var createResult = await _userManager.CreateAsync(Usermapper, request.Password);
                // create successed
                if (!createResult.Succeeded)
                {
                    return BadRequest<string>(_sharedResources[SharedResourcesKeys.FaildToAddUser]);

                }
                // create failed
                return Created<string>(_sharedResources[SharedResourcesKeys.Created]);

            }

            return UnprocessableEntity<string>(_sharedResources[SharedResourcesKeys.EmailIsExist]);

        }
        #endregion

    }
}
