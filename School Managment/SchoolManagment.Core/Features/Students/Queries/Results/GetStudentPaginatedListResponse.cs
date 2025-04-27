namespace SchoolManagment.Core.Features.Students.Queries.Results
{
    public class GetStudentPaginatedListResponse
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? DeptName { get; set; }
        public GetStudentPaginatedListResponse(int stdId, string name, string address, string Deptname)
        {
            StudentId = stdId;
            Name = name;
            Address = address;
            DeptName = Deptname;

        }
    }
}
