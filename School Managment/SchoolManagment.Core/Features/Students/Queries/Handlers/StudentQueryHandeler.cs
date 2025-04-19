using AutoMapper;
using MediatR;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Students.Queries.Models;
using SchoolManagment.Core.Features.Students.Queries.Results;
using SchoolManagment.Data.Entities;
using SchoolManagment.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandeler :ResponseHandler, 
        IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
        IRequestHandler<GetStudentByIDQuery, Response<GetSingleStudentResponse>>

    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;


        #endregion
        #region CTOR
        public StudentQueryHandeler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;

        }





        #endregion
        #region Handle Functions
        //public async Task<List<GetStudentListResponse>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        //{
        //    var StudentList =  await _studentService.GetStudentsListAsync();
        //    var StudentListMapper = _mapper.Map<List<GetStudentListResponse>>(StudentList);
        //    return StudentListMapper;
        //}
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var StudentList = await _studentService.GetStudentsListAsync();
            var StudentListMapper = _mapper.Map<List<GetStudentListResponse>>(StudentList);
            return Success(StudentListMapper);
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
        {
            var student =await _studentService.GetStudentsByIdAsync(request.Id);
            if (student == null)
            {
                return NotFound<GetSingleStudentResponse>();
            }
            var Result = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(Result);
        }

        #endregion

    }
}
