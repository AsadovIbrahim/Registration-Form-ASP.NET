using FluentValidation;
using Register_Form_Project.Models;

namespace Register_Form_Project.Validators.FluentValidators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(15);

            RuleFor(x => x.Email)
                .EmailAddress().NotEmpty()
                .WithMessage("Email can't be empty");

            RuleFor(x => x.Password)
               .NotEmpty().WithMessage("Password can't be empty")
               .MinimumLength(6).WithMessage("Password can be minimum 6 symbol!")
               .MaximumLength(18).WithMessage("Password can be maximum 18 symbol")
               .Matches(@"[A-Z]+").WithMessage("Passwordda en azi bir boyuk herf olmalidir")
               .Matches(@"[a-z]+").WithMessage("Passwordda en azi bir kicik herf olmalidir")
               .Matches(@"[0-9]+").WithMessage("Passwordda en azi bir reqem olmalidir");

            RuleFor(p => p.ConfirmPassword)
            .Equal(p => p.Password).WithMessage("Password And Confirm Password Must be Same!");
        }
    }
}
