using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.ApplicationUser.Queries.Models;
using SchoolManagment.Core.Features.ApplicationUser.Queries.Results;
using SchoolManagment.Core.Resources;
using SchoolManagment.Core.Wrappers;
using SchoolManagment.Data.Entities.Identity;

namespace SchoolManagment.Core.Features.ApplicationUser.Queries.Handler
{
    public class UserQueryHandler : ResponseHandler,
        IRequestHandler<GetUserPaginationQuery, PaginatedResult<GetUserPaginationReponse>>,
        IRequestHandler<GetUserByEmailQuery, Response<GetUserByEmailResponse>>
    {
        #region Fields
        private readonly UserManager<User> _User;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Ctor
        public UserQueryHandler(UserManager<User> User, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _User = User;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region Handler function

        public async Task<PaginatedResult<GetUserPaginationReponse>> Handle(GetUserPaginationQuery request, CancellationToken cancellationToken)
        {
            var users = _User.Users.AsQueryable();
            var paginatedlist = await _mapper.ProjectTo<GetUserPaginationReponse>(users).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedlist;
        }

        public async Task<Response<GetUserByEmailResponse>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _User.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return NotFound<GetUserByEmailResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }
            var usermapper = _mapper.Map<GetUserByEmailResponse>(user);
            return Success<GetUserByEmailResponse>(usermapper);

        }
        #endregion

    }
}
