using FluentValidation;

namespace CleanArch.StarterKit.Application.Feature.Examples.Commands.CreateExample;
public sealed class CreateExampleValidator : AbstractValidator<CreateExampleCommand>
{
    public CreateExampleValidator()
    {
        RuleFor(p => p.Value1).NotEmpty().WithMessage("Value1 cannot be empty!");
        RuleFor(p => p.Value1).MinimumLength(3);

        RuleFor(p => p.Value2).NotNull().WithMessage("Value2 cannot be null!");
        RuleFor(p => p.Value2).GreaterThan(0).WithMessage("Value2 must be greater than 0!");

        RuleFor(p => p.Value3).NotNull().WithMessage("Value3 cannot be null!");
    }
}
