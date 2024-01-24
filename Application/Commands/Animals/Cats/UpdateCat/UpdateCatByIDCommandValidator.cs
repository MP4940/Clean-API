using FluentValidation;
using Infrastructure.Repositories.Animals.Cats;

namespace Application.Commands.Animals.Cats.UpdateCat
{
    public class UpdateCatByIDCommandValidator : AbstractValidator<UpdateCatByIDCommand>
    {
        private readonly ICatRepository _catRepository;
        public UpdateCatByIDCommandValidator(ICatRepository catRepository)
        {
            _catRepository = catRepository;

            RuleFor(command => command.UpdatedCat.Name)
            .NotEmpty().WithMessage("Name is required.");
        }
    }
}