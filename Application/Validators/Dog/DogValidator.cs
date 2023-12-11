using Application.Dtos.AnimalsDtos.DogDto;
using FluentValidation;

namespace Application.Validators.Dog
{
    public class DogValidator : AbstractValidator<DogDto>
    {
        public DogValidator()
        {
            RuleFor(dog => dog.Name)
                .NotEmpty().WithMessage("Dog name cannot be empty")
                .NotNull().WithMessage("Dog name cannot be null");
        }
    }
}
