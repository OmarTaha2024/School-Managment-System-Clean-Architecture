using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Authorization.Commands.Models;
using SchoolManagment.Core.Resources;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Core.Features.Authorization.Commands.Handler
{
    public class RoleCommandHandler : ResponseHandler,
        IRequestHandler<AddRoleCommand, Response<string>>,
        IRequestHandler<EditRoleCommand, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IAuthorizationService _authorizationService;

        #endregion
        #region ctor
        public RoleCommandHandler(IStringLocalizer<SharedResources> localizer, IAuthorizationService authorizationService) : base(localizer)
        {
            _localizer = localizer;
            _authorizationService = authorizationService;
        }
        #endregion
        #region validation methods
        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.AddRoleAsync(request.RoleName);
            if (result == "Added") return Created<string>(_localizer[SharedResourcesKeys.Created]);
            return BadRequest<string>(_localizer[SharedResourcesKeys.AddFailed]);
        }

        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.EditRoleAsync(request);
            if (result == "Not Found") return NotFound<string>();
            else if (result == "Success") return Success((string)_localizer[SharedResourcesKeys.Updated]);
            else
                return BadRequest<string>(result);
        }
        #endregion
    }
}
