using FluentValidation;
using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Service.Abstracts;

namespace SchoolManagment.Core.Features.Students.Commands.Validators
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region Feilds
        private readonly IStudentService _studentService;
        #endregion

        #region ctor
        public EditStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion
        #region Actions
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Must not be Empty")
                                .NotNull().WithMessage("Must not be null")
                .MaximumLength(10).WithMessage("Name Must be less than or equal 10 character");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Must not be Empty");

        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(key, model.Id)).WithMessage("Name is Exist");
        }
        #endregion
    }
}

