using FluentValidation;
using Infrastructure.Repositories.Animals.Dogs;

namespace Application.Commands.Animals.Dogs.AddDog
{
    public class AddDogCommandValidator : AbstractValidator<AddDogCommand>
    {
        private readonly IDogRepository _dogRepository;
        public AddDogCommandValidator(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;

            RuleFor(command => command.NewDog.Name)
            .NotEmpty().WithMessage("Name is required.");
        }
    }
}