using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Students.Queries.Models;
using SchoolManagment.Core.Features.Students.Queries.Results;
using SchoolManagment.Core.Resources;
using SchoolManagment.Core.Wrappers;
using SchoolManagment.Data.Entities;
using SchoolManagment.Service.Abstracts;
using System.Linq.Expressions;

namespace SchoolManagment.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandeler : ResponseHandler,
        IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
        IRequestHandler<GetStudentByIDQuery, Response<GetSingleStudentResponse>>,
        IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>

    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;


        #endregion
        #region CTOR
        public StudentQueryHandeler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;


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

            var StudentListMapper = _studentService.GetStudentsQueryableList().ProjectTo<GetStudentListResponse>(_mapper.ConfigurationProvider).ToList();

            var Result = Success(StudentListMapper);
            Result.Meta = new { count = StudentListMapper.Count() };
            return Result;
            //// Using Auto Mapper 
            //var StudentList = await _studentService.GetStudentsListAsync();
            //var StudentListMapper = _mapper.Map<List<GetStudentListResponse>>(StudentList);
            //var Result = Success(StudentListMapper);
            //Result.Meta = new { count = StudentListMapper.Count() };
            //return Result;

        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentsByIdwithIncludeAsync(request.Id);
            if (student == null)
            {
                return NotFound<GetSingleStudentResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }
            var Result = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(Result);
        }
        /// <summary>
        ///  make projection in database not as auto mappeer in RAM
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Task<PaginatedResult<GetStudentPaginatedListResponse>></returns>
        //public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        //{
        //    Expression<Func<Student, GetStudentPaginatedListResponse>> ex = ex => new GetStudentPaginatedListResponse(ex.StudID, ex.NameAr, ex.NameEn, ex.Address, ex.Department.DNameAr, ex.Department.DNameEn);
        //    //  var queryable = _studentService.GetStudentsQueryableList();
        //    var filterqueryable = _studentService.FilterStudentsPaginatedQueryable(request.OrderBy, request.Search);
        //    var paginatedlist = await filterqueryable.Select(ex).ToPaginatedListAsync(request.PageNumber, request.PageSize);
        //    var culture = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower();

        //    foreach (var item in paginatedlist.Data)
        //    {
        //        item.Name = culture == "ar" ? item.NameAr : item.NameEn;
        //        item.DeptName = culture == "ar" ? item.DeptNameAr : item.DeptNameEn;
        //    }
        //    var result = paginatedlist;
        //    result.Meta = new { count = paginatedlist.Data.Count() };
        //    return paginatedlist;
        //}

        /// Another way for projection  make projection in database not as auto mappeer in RAM

        //public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        //{
        //    Expression<Func<Student, GetStudentPaginatedListResponse>> ex;
        //    var culture = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower();
        //    if (culture == "ar")
        //    {
        //        ex = s => new GetStudentPaginatedListResponse
        //        (s.StudID,
        //            s.NameAr,
        //            s.Address,
        //             s.Department.DNameAr);
        //    }
        //    else
        //    {
        //        ex = s => new GetStudentPaginatedListResponse
        //        (s.StudID,
        //            s.NameEn,
        //            s.Address,
        //             s.Department.DNameEn);
        //    }

        //    //  var queryable = _studentService.GetStudentsQueryableList();
        //    var filterqueryable = _studentService.FilterStudentsPaginatedQueryable(request.OrderBy, request.Search);
        //    var paginatedlist = await filterqueryable.Select(ex).ToPaginatedListAsync(request.PageNumber, request.PageSize);
        //    var result = paginatedlist;
        //    result.Meta = new { count = paginatedlist.Data.Count() };
        //    return paginatedlist;
        //}
        /// using bad way for orjection beacuse it made on RAM
        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> ex = ex => new GetStudentPaginatedListResponse(ex.StudID, ex.GetLocalized(ex.NameAr, ex.NameEn), ex.Address, ex.Department.GetLocalized(ex.NameAr, ex.NameEn));
            //  var queryable = _studentService.GetStudentsQueryableList();
            var filterqueryable = _studentService.FilterStudentsPaginatedQueryable(request.OrderBy, request.Search);
            var paginatedlist = await filterqueryable.Select(ex).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            var result = paginatedlist;
            result.Meta = new { count = paginatedlist.Data.Count() };
            return paginatedlist;
        }
        #endregion

    }
}
