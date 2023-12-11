using Application.Dtos.AnimalsDtos.BirdDto;
using FluentValidation;

namespace Application.Validators.Bird
{
    public class BirdValidator : AbstractValidator<BirdDto>
    {
        public BirdValidator()
        {
            RuleFor(bird => bird.Name)
                .NotEmpty().WithMessage("Bird name cannot be empty")
                .NotNull().WithMessage("Bird name cannot be null");
        }
    }
}