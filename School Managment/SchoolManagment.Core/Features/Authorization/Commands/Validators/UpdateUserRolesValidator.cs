using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagment.Core.Features.Authorization.Commands.Models;
using SchoolManagment.Core.Resources;


namespace SchoolManagment.Core.Features.Authorization.Commands.Validators
{
    public class UpdateUserRolesValidator : AbstractValidator<UpdateUserRolesCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;

        #endregion
        #region ctor
        public UpdateUserRolesValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion
        #region validation methods
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

        }

        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}
