using FluentValidation;
using Infrastructure.Repositories.Animals.Cats;

namespace Application.Commands.Animals.Cats.AddCat
{
    public class AddCatCommandValidator : AbstractValidator<AddCatCommand>
    {
        private readonly ICatRepository _catRepository;
        public AddCatCommandValidator(ICatRepository catRepository)
        {
            _catRepository = catRepository;

            RuleFor(command => command.NewCat.Name)
            .NotEmpty().WithMessage("Name is required.");
        }
    }
}