using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Students.Queries.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Core.Features.Students.Queries.Models
{
    public class GetStudentByIDQuery : IRequest<Response<GetSingleStudentResponse>>
    {
        public int Id { get; set; }
        public GetStudentByIDQuery(int id)
        {
            Id= id;
        }
    }
}
