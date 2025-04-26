using FluentValidation;
using SimpleBank.Communication.Requests;
namespace SimpleBank.Application.UseCases.User.Register
{
    public class CreateUserValidator : AbstractValidator<RequestCreateUserJson>
    {
        public CreateUserValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

            RuleFor(x => x.Password).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Password is required.")
                .Length(6, 20).WithMessage("Password must be between 6 and 20 characters.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one number.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");

            RuleFor(x => x.Document).NotEmpty().WithMessage("Document number is required.");

        }
    }
}
