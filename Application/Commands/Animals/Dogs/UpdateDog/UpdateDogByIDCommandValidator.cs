using FluentValidation;
using Infrastructure.Repositories.Animals.Dogs;

namespace Application.Commands.Animals.Dogs.UpdateDog
{
    public class UpdateDogByIDCommandValidator : AbstractValidator<UpdateDogByIDCommand>
    {
        private readonly IDogRepository _DogRepository;
        public UpdateDogByIDCommandValidator(IDogRepository DogRepository)
        {
            _DogRepository = DogRepository;

            RuleFor(command => command.UpdatedDog.Name)
            .NotEmpty().WithMessage("Name is required.");
        }
    }
}
