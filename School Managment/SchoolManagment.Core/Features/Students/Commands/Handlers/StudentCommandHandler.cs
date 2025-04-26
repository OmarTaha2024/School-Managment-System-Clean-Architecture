using AutoMapper;
using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Data.Entities;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
        IRequestHandler<AddStudentCommand, Response<String>>,
        IRequestHandler<EditStudentCommand, Response<String>>
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
            if (result == "Added Successfully")
                return Created<string>("Added Successfully");
            else
                return BadRequest<string>();
            //return Responce 
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            //check if student is exsit or not 
            var student = await _studentService.GetStudentsByIdAsync(request.Id);
            // return not found 
            if (student == null) return NotFound<string>();
            //Mapping Between Request and Student 
            var studentmapper = _imapper.Map<Student>(request);

            // call service for edit 
            var result = await _studentService.UpdataAsync(studentmapper);

            //return response
            if (result == "Updated Successfully")
                return Success<string>("Updated Successfully");
            return BadRequest<string>();
        }
        #endregion

    }
}
