using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Core.Resources;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Core.Features.Students.Commands.Validators
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region Feilds
        private readonly IStudentService _studentService;
        #endregion
        private readonly IStringLocalizer<SharedResources> _Localizer;

        #region ctor
        public EditStudentValidator(IStudentService studentService, IStringLocalizer<SharedResources> stringLocalizer)
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
            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage(_Localizer[SharedResourcesKeys.NotEmpty])
                                .NotNull().WithMessage(_Localizer[SharedResourcesKeys.Required])
                .MaximumLength(10).WithMessage(_Localizer[SharedResourcesKeys.MaxLengthis10]);
            RuleFor(x => x.NameAr)
                .NotEmpty().WithMessage(_Localizer[SharedResourcesKeys.NotEmpty])
                                .NotNull().WithMessage(_Localizer[SharedResourcesKeys.Required])
                .MaximumLength(10).WithMessage(_Localizer[SharedResourcesKeys.MaxLengthis10]);
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(_Localizer[SharedResourcesKeys.NotEmpty]);

        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.NameAr)
                .MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameExistExcludeSelfAr(key, model.Id)).WithMessage(_Localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn)
                .MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameExistExcludeSelfEn(key, model.Id)).WithMessage(_Localizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }
}

