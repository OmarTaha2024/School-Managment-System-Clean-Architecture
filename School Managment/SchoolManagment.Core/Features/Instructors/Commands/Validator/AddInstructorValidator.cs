using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Features.Instructors.Commands.Model;
using SchoolManagment.Core.Resources;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Core.Features.Instructors.Commands.Validator
{
    public class AddInstructorValidator : AbstractValidator<AddInstructorCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IDepartmentService _departmentService;
        private readonly IInstructorService _instructorService;
        #endregion

        #region Constructors
        public AddInstructorValidator(IStringLocalizer<SharedResources> localizer,
                                      IDepartmentService departmentService,
                                      IInstructorService instructorService)
        {
            _localizer = localizer;
            _instructorService = instructorService;
            _departmentService = departmentService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();

        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.NameAr)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.NameEn)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.DID)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.NameAr)
                .MustAsync(async (Key, CancellationToken) => !await _instructorService.IsNameArExist(Key))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn)
               .MustAsync(async (Key, CancellationToken) => !await _instructorService.IsNameEnExist(Key))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.DID)
           .MustAsync(async (Key, CancellationToken) => await _departmentService.IsDeptExist(Key))
           .WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);

        }

        #endregion

    }
}
