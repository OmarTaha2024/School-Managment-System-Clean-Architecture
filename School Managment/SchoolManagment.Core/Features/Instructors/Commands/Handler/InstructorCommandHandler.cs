﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Bases;
using SchoolManagment.Core.Features.Instructors.Commands.Model;
using SchoolManagment.Core.Resources;
using SchoolManagment.Data.Entities;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Core.Features.Instructors.Commands.Handler
{
    public class InstructorCommandHandler : ResponseHandler,
                          IRequestHandler<AddInstructorCommand, Response<string>>
    {

        #region Fileds
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IInstructorService _instructorService;
        #endregion
        #region Constructors
        public InstructorCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                        IMapper mapper,
                                        IInstructorService instructorService) : base(stringLocalizer)
        {
            _instructorService = instructorService;
            _mapper = mapper;
            _localizer = stringLocalizer;
        }


        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructor = _mapper.Map<Instructor>(request);
            var result = await _instructorService.AddInstructorAsync(instructor, request.Image);
            switch (result)
            {
                case "NoImage": return BadRequest<string>(_localizer[SharedResourcesKeys.NoImage]);
                case "FailedToUploadImage": return BadRequest<string>(_localizer[SharedResourcesKeys.FailedToUploadImage]);
                case "FailedInAdd": return BadRequest<string>(_localizer[SharedResourcesKeys.AddFailed]);
            }
            return Success("");
        }
        #endregion
    }
}
