using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Departments.Queries.Models;
using SchoolManagment.Core.Features.Departments.Queries.Results;
using SchoolManagment.Core.Resources;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Core.Features.Departments.Queries.Handlers
{
    public class DepartmentQueryHandeler : ResponseHandler, IRequestHandler<GetDepartmentByIDQuery, Response<GetSingleDepartmentResponse>>
    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #region CTOR
        public DepartmentQueryHandeler(IDepartmentService departmentService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _departmentService = departmentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;


        }





        #endregion
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
            return Success(department_mapper);
        }
    }
}
