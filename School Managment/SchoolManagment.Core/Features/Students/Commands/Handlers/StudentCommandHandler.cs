using AutoMapper;
using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Data.Entities;
using SchoolManagment.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<String>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _imapper;


        #endregion
        #region Ctor
        public StudentCommandHandler(IStudentService studentService, IMapper imapper)
        {
            _studentService = studentService;
            _imapper = imapper;

        }
        #endregion
        #region Handling Method 
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            //Mapping Between Request and Student 
            var studentmapper = _imapper.Map<Student>(request);
            // Add using Service 
            var result = await _studentService.AddAsync(studentmapper);
            //check condition
            if (result == "Exist")
            {
                return UnprocessableEntity<string>("Name is Exist");
            }
            else if (result == "Added Successfully")
                return Created<string>("Added Successfully");
            else 
                return BadRequest<string>();
            //return Responce 
        }
        #endregion

    }
}
