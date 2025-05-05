using MediatR;
using SchoolManagment.Core.Features.ApplicationUser.Queries.Results;
using SchoolManagment.Core.Wrappers;

namespace SchoolManagment.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUserPaginationQuery : IRequest<PaginatedResult<GetUserPaginationReponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
