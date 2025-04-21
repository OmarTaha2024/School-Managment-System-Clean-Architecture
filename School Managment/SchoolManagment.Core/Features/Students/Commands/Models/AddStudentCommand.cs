using SchoolManagment.Core.Bases;

using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand :IRequest<Response<String>>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
        public string? Phone { get; set; }

        [Required]

        public int DepartmentID { get; set; }
    }
}
