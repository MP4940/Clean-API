using FluentValidation;
using Infrastructure.Repositories.Animals.Dogs;

namespace Application.Commands.Animals.Dogs.UpdateDog
{
    public class UpdateDogByIDCommandValidator : AbstractValidator<UpdateDogByIDCommand>
    {
        private readonly IDogRepository _dogRepository;
        public UpdateDogByIDCommandValidator(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;

            RuleFor(command => command.UpdatedDog.Name)
            .NotEmpty().WithMessage("Name is required.");
        }
    }
}
