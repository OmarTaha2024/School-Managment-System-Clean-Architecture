using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Core.Resources;
using SchoolManagment.Data.Entities;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
        IRequestHandler<AddStudentCommand, Response<String>>,
        IRequestHandler<EditStudentCommand, Response<String>>,
        IRequestHandler<DeleteStudentCommand, Response<String>>

    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _imapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;


        #endregion
        #region Ctor
        public StudentCommandHandler(IStudentService studentService, IMapper imapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _imapper = imapper;
            _stringLocalizer = stringLocalizer;


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
                return Created<string>(_stringLocalizer[SharedResourcesKeys.Created]);
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
            var studentmapper = _imapper.Map(request, student);

            // call service for edit 
            var result = await _studentService.UpdataAsync(studentmapper);

            //return response
            if (result == "Updated Successfully")
                return Success<string>(_stringLocalizer[SharedResourcesKeys.Success]);
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //check if student is exsit or not 
            var student = await _studentService.GetStudentsByIdAsync(request.ID);
            // return not found 
            if (student == null) return NotFound<string>();
            // call service for edit 
            var result = await _studentService.DeleteAsync(student);

            //return response
            if (result == "Deleted Successfully")
                return Deleted<string>();
            else return Deleted<string>(_stringLocalizer[SharedResourcesKeys.DeletedFailed]);
        }
        #endregion

    }
}
