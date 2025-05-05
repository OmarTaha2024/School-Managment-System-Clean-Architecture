using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Features.ApplicationUser.Commands.Models;
using SchoolManagment.Core.Resources;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Core.Features.ApplicationUser.Commands.Validatiors
{
    public class EditUservalidator : AbstractValidator<EditUserCommand>
    {

        #region Feilds
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _Localizer;
        #endregion

        #region ctor
        public EditUservalidator(IStudentService studentService, IStringLocalizer<SharedResources> stringLocalizer)
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
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage(_Localizer[SharedResourcesKeys.NotEmpty])
                                .NotNull().WithMessage(_Localizer[SharedResourcesKeys.Required])
                .MaximumLength(10).WithMessage(_Localizer[SharedResourcesKeys.MaxLengthis10]);
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_Localizer[SharedResourcesKeys.NotEmpty])
                                .NotNull().WithMessage(_Localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(_Localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_Localizer[SharedResourcesKeys.Required]); ;
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage(_Localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_Localizer[SharedResourcesKeys.Required]); ;
            RuleFor(x => x.PhoneNumber)
               .NotEmpty().WithMessage(_Localizer[SharedResourcesKeys.NotEmpty])
               .NotNull().WithMessage(_Localizer[SharedResourcesKeys.Required]); ;

        }
        public void ApplyCustomValidationRules()
        {

        }
        #endregion
    }
}
