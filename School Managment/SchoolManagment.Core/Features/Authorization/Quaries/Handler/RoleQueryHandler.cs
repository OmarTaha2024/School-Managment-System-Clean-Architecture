using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Authorization.Quaries.Models;
using SchoolManagment.Core.Features.Authorization.Quaries.Results;
using SchoolManagment.Core.Resources;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Core.Features.Authorization.Quaries.Handler
{
    public class RoleQueryHandler : ResponseHandler,
       IRequestHandler<GetRolesListQuery, Response<List<GetRolesListResult>>>
    {
        #region Fields
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<User> _userManager;
        #endregion
        #region Ctor
        public RoleQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, IAuthorizationService authorizationService, IMapper mapper, UserManager<User> userManager) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion
        #region Handle Function
        public async Task<Response<List<GetRolesListResult>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationService.GetRolesList();
            var result = _mapper.Map<List<GetRolesListResult>>(roles);
            return Success(result);
        }
        #endregion

    }
}
