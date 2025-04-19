using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Core.Features.Students.Queries.Results
{
    public class GetSingleStudentResponse
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? DeptName { get; set; }
    }
}
