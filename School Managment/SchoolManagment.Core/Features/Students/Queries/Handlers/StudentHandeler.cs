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
    internal class StudentHandeler :ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;


        #endregion
        #region CTOR
        public StudentHandeler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;

        }

        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var StudentList = await _studentService.GetStudentsListAsync();
            var StudentListMapper = _mapper.Map<List<GetStudentListResponse>>(StudentList);
            return Success(StudentListMapper);
        }
        #endregion
        #region Handle Functions
        //public async Task<List<GetStudentListResponse>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        //{
        //    var StudentList =  await _studentService.GetStudentsListAsync();
        //    var StudentListMapper = _mapper.Map<List<GetStudentListResponse>>(StudentList);
        //    return StudentListMapper;
        //}


        #endregion

    }
}
