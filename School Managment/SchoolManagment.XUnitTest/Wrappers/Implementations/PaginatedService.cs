using SchoolManagment.Core.Wrappers;
using SchoolManagment.Data.Entities;
using SchoolManagment.XUnitTest.Wrappers.Interfaces;

namespace SchoolManagment.XUnitTest.Wrappers.Implementations
{
    public class PaginatedService : IPaginatedService<Student>
    {
        public async Task<PaginatedResult<Student>> ReturnPaginatedResult(IQueryable<Student> source, int pageNumber, int pageSize)
        {
            return await source.ToPaginatedListAsync(pageNumber, pageSize);
        }
    }
}
