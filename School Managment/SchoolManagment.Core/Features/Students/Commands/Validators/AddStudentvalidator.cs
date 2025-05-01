using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Core.Resources;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Core.Features.Students.Commands.Validators
{
    public class AddStudentvalidator : AbstractValidator<AddStudentCommand>
    {
        #region Feilds
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _Localizer;

        #endregion
        #region ctor
        public AddStudentvalidator(IStudentService studentService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _studentService = studentService;
            _Localizer = stringLocalizer;

            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion
        #region Actions
        public void ApplyValidationRules()
        {
            RuleFor(x => x.NameAr)
                .NotEmpty().WithMessage(_Localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_Localizer[SharedResourcesKeys.Required])
                .MaximumLength(10).WithMessage(_Localizer[SharedResourcesKeys.MaxLengthis10]);
            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage(_Localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_Localizer[SharedResourcesKeys.Required])
                .MaximumLength(10).WithMessage(_Localizer[SharedResourcesKeys.MaxLengthis10]);
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(_Localizer[SharedResourcesKeys.NotEmpty]);

        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.NameAr)
                .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameExistAr(key)).WithMessage(_Localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn)
                .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameExistEn(key)).WithMessage(_Localizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }
}
