using MediatR;
using SchoolManagment.Core.Features.Students.Queries.Results;
using SchoolManagment.Core.Wrappers;

namespace SchoolManagment.Core.Features.Students.Queries.Models
{
    public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string[]? OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
