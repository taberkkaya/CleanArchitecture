using FluentValidation;

namespace CleanArch.StarterKit.Application.Feature.Auth.Commands.Register;
public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(p => p.Email).NotEmpty().EmailAddress()
            .WithMessage("Email is required and must be a valid email address.");

        RuleFor(p => p.Password).NotEmpty()
            .WithMessage("Password is required.")
            .MinimumLength(6)
            .WithMessage("Password must be at least 6 characters long.");

        RuleFor(p => p.Password)
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d@$!%*?&]{6,}$")
            .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, and one number.");

        RuleFor(p =>p.UserName).NotEmpty()
            .WithMessage("Username is required.")
            .MinimumLength(3)
            .WithMessage("Username must be at least 3 characters long.");

        RuleFor(p => p.FirstName).NotEmpty()
            .WithMessage("First name is required.")
            .MinimumLength(2)
            .WithMessage("First name must be at least 2 characters long.");

        RuleFor(p => p.LastName).NotEmpty()
            .WithMessage("Last name is required.")
            .MinimumLength(2)
            .WithMessage("Last name must be at least 2 characters long.");
    }
}
