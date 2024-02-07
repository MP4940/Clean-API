using FluentValidation;

namespace Application.Validators
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator()
        {
            Validate();
        }
        public void Validate()
        {
            RuleFor(guid => guid)
                .NotEmpty().WithMessage("Guid should not be empty")
                .NotEqual(Guid.Empty).WithMessage("Guid cannot be empty Guid");
        }
    }
}