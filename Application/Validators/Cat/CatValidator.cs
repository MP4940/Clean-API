using Application.Dtos.AnimalsDtos.CatDto;
using FluentValidation;

namespace Application.Validators.Cat
{
    public class CatValidator : AbstractValidator<CatDto>
    {
        public CatValidator()
        {
            RuleFor(cat => cat.Name)
                .NotEmpty().WithMessage("Cat name cannot be empty")
                .NotNull().WithMessage("Cat name cannot be null");
        }
    }
}