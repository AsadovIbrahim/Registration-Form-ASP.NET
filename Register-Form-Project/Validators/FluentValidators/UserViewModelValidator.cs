using FluentValidation;
using Register_Form_Project.ViewModels;

namespace Register_Form_Project.Validators.FluentValidators
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(x => x.Username)
                    .NotEmpty()
                    .WithMessage("Username can't be empty");

            RuleFor(x => x.Password)
                   .NotEmpty().WithMessage("Password can't be empty")
                   .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
                   .MaximumLength(18).WithMessage("Password can't be longer than 18 characters");

        }
    }
}
