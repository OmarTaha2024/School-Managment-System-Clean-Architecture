﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Departments.Queries.Models;
using SchoolManagment.Core.Features.Departments.Queries.Results;
using SchoolManagment.Core.Resources;
using SchoolManagment.Core.Wrappers;
using SchoolManagment.Data.Entities;
using SchoolManagment.Data.Entities.Procedures;
using SchoolManagment.Service.Abstracts;
using Serilog;
using System.Linq.Expressions;

namespace SchoolManagment.Core.Features.Departments.Queries.Handlers
{
    public class DepartmentQueryHandeler : ResponseHandler, IRequestHandler<GetDepartmentByIDQuery, Response<GetSingleDepartmentResponse>>,
        IRequestHandler<GetDepartmentStudentListCountQuery, Response<List<GetDepartmentStudentListCountResults>>>,
        IRequestHandler<GetDepartmentStudentCountByIDQuery, Response<GetDepartmentStudentCountByIDResult>>

    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IStudentService _studentService;
        #endregion

        #region CTOR
        public DepartmentQueryHandeler(IDepartmentService departmentService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer, IStudentService studentService) : base(stringLocalizer)
        {
            _departmentService = departmentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
            _studentService = studentService;


        }

        #endregion
        public async Task<Response<GetSingleDepartmentResponse>> Handle(GetDepartmentByIDQuery request, CancellationToken cancellationToken)
        {
            // Service get by id include st ,sub , ins
            var department = await _departmentService.GetDepartmentByIdAsync(request.ID);
            // check if exist 
            if (department == null)
            {
                return NotFound<GetSingleDepartmentResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }
            // mapping
            var department_mapper = _mapper.Map<GetSingleDepartmentResponse>(department);
            // pagination
            Expression<Func<Student, StudentResponse>> ex = ex => new StudentResponse(ex.StudID, ex.GetLocalized(ex.NameAr, ex.NameEn));
            var queryable = _studentService.GetStudentQueryableList(request.ID);
            var paginatedlist = await queryable.Select(ex).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            department_mapper.studentList = paginatedlist;
            Log.Information($"Get Department By Id {request.ID}!");
            return Success(department_mapper);
        }

        public async Task<Response<List<GetDepartmentStudentListCountResults>>> Handle(GetDepartmentStudentListCountQuery request, CancellationToken cancellationToken)
        {
            var Departmentlist = await _departmentService.GetViewDepartmentDataAsync();
            var mapperlist = _mapper.Map<List<GetDepartmentStudentListCountResults>>(Departmentlist);
            return Success<List<GetDepartmentStudentListCountResults>>(mapperlist);
        }

        public async Task<Response<GetDepartmentStudentCountByIDResult>> Handle(GetDepartmentStudentCountByIDQuery request, CancellationToken cancellationToken)
        {
            var parameters = _mapper.Map<DepartmentStudentCountProcParameter>(request);
            var procResult = await _departmentService.GetDepartmentStudentCountProcsService(parameters);
            var result = _mapper.Map<GetDepartmentStudentCountByIDResult>(procResult.FirstOrDefault());
            return Success(result);
        }
    }
}
