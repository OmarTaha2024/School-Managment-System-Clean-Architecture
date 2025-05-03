using SchoolManagment.Core.Wrappers;

namespace SchoolManagment.Core.Features.Departments.Queries.Results
{
    public class GetSingleDepartmentResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public PaginatedResult<StudentResponse>? studentList { get; set; }
        public List<SubjectResponse>? subjectList { get; set; }
        public List<InstructorsResponse>? InstructorsList { get; set; }

    }
    public class StudentResponse
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public StudentResponse(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
    public class SubjectResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class InstructorsResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
