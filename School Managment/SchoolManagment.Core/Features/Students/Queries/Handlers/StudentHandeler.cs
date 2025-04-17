using AutoMapper;
using MediatR;
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
    internal class StudentHandeler : IRequestHandler<GetStudentListQuery, List<GetStudentListResponse>>
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
        #endregion
        #region Handle Functions
        public async Task<List<GetStudentListResponse>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var StudentList =  await _studentService.GetStudentsListAsync();
            var StudentListMapper = _mapper.Map<List<GetStudentListResponse>>(StudentList);
            return StudentListMapper;
        }
        #endregion

    }
}
